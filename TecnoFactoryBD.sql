-- Crear la base de datos
CREATE DATABASE TecnoFactoryBD;

-- Seleccionar la base de datos
USE TecnoFactoryBD;

-- Crear la tabla users
CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    docnumber VARCHAR(20) NOT NULL,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    state VARCHAR(20),
    UNIQUE (docnumber, email)
);

-- Crear la tabla favorite
CREATE TABLE favorite (
    id INT IDENTITY(1,1) PRIMARY KEY,
    docnumber VARCHAR(20) NOT NULL,
    email VARCHAR(100) NOT NULL,
    idcomic INT NOT NULL,
    state VARCHAR(20),
    FOREIGN KEY (docnumber, email) REFERENCES users(docnumber, email)
);