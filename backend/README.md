# Az adatbázis

```sql
CREATE DATABASE IF NOT EXISTS appdb;
USE appdb;

CREATE TABLE users (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    description TEXT,
    imageUrl VARCHAR(500),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);
```
