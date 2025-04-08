import express from 'express';
import mysql from 'mysql2';
import cors from 'cors';
import multer from 'multer';
import path from 'path';
import fs from 'fs';

const app = express();
const PORT = 5000;

app.use(cors());
app.use(express.json());
app.use('/uploads', express.static('uploads')); // statikus fájlok kiszolgálása

// uploads mappa létrehozása, ha nem létezik
if (!fs.existsSync('./uploads')) {
    fs.mkdirSync('./uploads');
}

// Multer konfiguráció – fájl mentése az uploads mappába
const storage = multer.diskStorage({
    destination: (req, file, cb) => cb(null, 'uploads/'),
    filename: (req, file, cb) => {
        const ext = path.extname(file.originalname);
        const uniqueName = Date.now() + '-' + Math.round(Math.random() * 1E9) + ext;
        cb(null, uniqueName);
    }
});
const upload = multer({ 
    storage,
    fileFilter: (req, file, cb) => {
        const allowedTypes = ['image/jpeg', 'image/png', 'image/gif', 'image/webp'];
        if (allowedTypes.includes(file.mimetype)) {
            cb(null, true);
        } else {
            cb(new Error('Csak képfájl tölthető fel (jpeg, png, gif, webp)!'));
        }
    }
});

const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '', // saját jelszavad
    database: 'appdb'
});

db.connect(err => {
    if (err) throw err;
    console.log('MySQL csatlakozva');
});

// GET /upload – összes felhasználó lekérdezése
app.get('/upload', (req, res) => {
    db.query('SELECT * FROM users', (err, results) => {
        if (err) return res.status(500).json({ error: err });
        res.json(results);
    });
});

// POST /upload – új felhasználó rögzítése és képfájl feltöltése
// Az uploads mappában lévő képek letöltése
app.get('/uploads/:userid', (req, res) => {
    const sql = 'SELECT imageUrl FROM users WHERE id = ?';
    db.query(sql, [req.params.userid], (err, results) => {
        if (err) return res.status(500).json({ error: err });
        if (results.length > 0) {
            const imageUrl = results[0].imageUrl;
            res.json({ imageUrl });
        } else {
            res.status(404).json({ error: 'Felhasználó nem található' });
        }
    });
    const filePath = path.join(__dirname, 'uploads', req.params.filename);
    res.download(filePath, err => {
        if (err) {
            console.error(err);
            res.status(404).send('Fájl nem található');
        }
    });
});

// A fájl és űrlapadatok kezelése multer-rel:
app.post('/upload', (req, res) => {
    upload.single('image')(req, res, err => {
        if (err instanceof multer.MulterError) {
            return res.status(400).json({ error: 'Feltöltési hiba', details: err.message });
        } else if (err) {
            return res.status(400).json({ error: 'Érvénytelen fájlformátum', details: err.message });
        }

        const { username, description } = req.body;
        const imageUrl = req.file ? `${req.file.filename}` : null;
        const createdAt = new Date();

        const sql = 'INSERT INTO users (username, description, imageUrl, created_at) VALUES (?, ?, ?, ?)';
        db.query(sql, [username, description, imageUrl, createdAt], (err, result) => {
            if (err) return res.status(500).json({ error: err });
            res.json({ message: 'Felhasználó mentve', id: result.insertId });
        });
    });
});

app.listen(PORT, () => {
    console.log(`Szerver fut: http://localhost:${PORT}/upload`);
});
