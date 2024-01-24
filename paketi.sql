-- Kreiranje baze podataka
CREATE DATABASE IF NOT EXISTS paketi;

-- Korišćenje baze podataka
USE paketi;

-- Kreiranje tabele klijent
CREATE TABLE IF NOT EXISTS klijent (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255),
    ime VARCHAR(255),
    prezime VARCHAR(255)
);

-- Ubacivanje podataka u tabelu klijent
INSERT INTO klijent (username, ime, prezime) VALUES
    ('mihajlo2', 'Mihajlo', 'Markovic'),
    ('ana8', 'Ana', 'Mitrovic'),
    ('stefan8', 'Stefan', 'Petrovic'),
    ('milica2', 'Milica', 'Kovacevic'),
    ('kristina4', 'Kristina', 'Novakovic'),
    ('marija8', 'Marija', 'Petronijevic'),
    ('katarina7', 'Katarina', 'Simovic'),
    ('milena1', 'Milena', 'Virijevic'),
    ('milica4', 'Milica', 'Vasojevic'),
    ('nikola7', 'Nikola', 'Kovacevic'),
    ('tamara1', 'Tamara', 'Savic'),
    ('djordje4', 'Djordje', 'Petrovic'),
    ('milos3', 'Milos', 'Jankovic'),
    ('hristina8', 'Hristina', 'Nikodijevic'),
    ('marina2', 'Marina', 'Krstic'),
    ('marko2', 'Marko', 'Mitrovic'),
    ('tijana7', 'Tijana', 'Popovic'),
    ('milan6', 'Milan', 'Nikolic'),
    ('jovana5', 'Jovana', 'Petrovic'),
    ('ivana5', 'Ivana', 'Jovanovic');

-- Kreiranje tabele tipoviPaketa
CREATE TABLE IF NOT EXISTS tipoviPaketa (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naziv VARCHAR(255)
);

-- Ubacivanje podataka u tabelu tipoviPaketa
INSERT INTO tipoviPaketa (id, naziv) VALUES
    (1, 'TV paket'),
    (2, 'Internet paket'),
    (3, 'Kombinovani paket');

-- Kreiranje tabele tvpaket
CREATE TABLE IF NOT EXISTS TVPaket (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naziv VARCHAR(255),
    cena DECIMAL(10, 2),
    broj_kanala INT,
    id_tipa INT,
    FOREIGN KEY (id_tipa) REFERENCES tipoviPaketa(id)
);

-- Ubacivanje podataka u tabelu tvpaket
INSERT INTO TVPaket (naziv, cena, broj_kanala, id_tipa) VALUES
    ('Osnovni paket', 1499.0, 100, 1),
    ('Sportski paket', 1899.0, 120, 1),
    ('Premium paket', 2199.0, 150, 1),
    ('Porodični paket', 2499.0, 200, 1);

-- Kreiranje tabele internetpaket
CREATE TABLE InternetPaket (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naziv VARCHAR(255),
    cena DECIMAL(10, 2),
    brzina_interneta INT,
    id_tipa INT,
    FOREIGN KEY (id_tipa) REFERENCES tipoviPaketa(id)
);

-- Ubacivanje podataka u tabelu internetpaket
INSERT INTO InternetPaket (naziv, cena, brzina_interneta, id_tipa) VALUES
    ('Osnovni internet', 1299.0, 50, 2),
    ('Brzi internet', 1699.0, 100, 2),
    ('Ultra internet', 2399.0, 200, 2),
    ('Poslovni internet', 3499.0, 500, 2);

-- Kreiranje tabele kombinovanipaket
CREATE TABLE KombinovaniPaket (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naziv VARCHAR(255),
    cena DECIMAL(10, 2),
    id_tv INT,
    id_net INT,
    id_tipa INT,
    FOREIGN KEY (id_tv) REFERENCES TVPaket(id),
    FOREIGN KEY (id_net) REFERENCES InternetPaket(id),
    FOREIGN KEY (id_tipa) REFERENCES tipoviPaketa(id)
);
-- Ubacivanje podataka u tabelu kombinovanipaket
INSERT INTO KombinovaniPaket (naziv, cena, id_tv, id_net, id_tipa) VALUES
    ('Osnovni paket', 2399.0, 1, 1, 3),
    ('Premium brzi paket', 3999.0, 3, 2, 3),
    ('Sportski paket + Brzi internet', 3699.0, 2, 2, 3),
    ('Porodični paket + Ultra internet', 4799.0, 4, 3, 3),
    ('Premium kombinovani paket', 4299.0, 3, 3, 3),
    ('Sportski paket + Osnovni', 2499.0, 2, 1, 3),
    ('Porodični + Brzi paket', 2899.0, 4, 2, 3),
    ('Premium + Poslovni paket', 5199.0, 3, 4, 3),
    ('Porodični + Poslovni paket', 5699.0, 4, 4, 3),
    ('Osnovni + Brzi paket', 1999.0, 1, 2, 3);


-- Kreiranje tabele aktiviraniPaket
CREATE TABLE aktiviraniPaketi (
    id_klijenta INT,
    id_tipa INT,
    id_paket INT,
    aktiviran BOOLEAN,
    FOREIGN KEY (id_klijenta) REFERENCES klijent(id),
    FOREIGN KEY (id_tipa) REFERENCES tipoviPaketa(id)

);
-- Ubacivanje podataka u tabelu aktiviraniPaket
INSERT INTO aktiviraniPaketi (id_klijenta, id_tipa, id_paket, aktiviran) VALUES
    (1, 1, 1, 1),
    (2, 1, 2 ,1),
    (3, 1, 3, 1),
    (4, 1, 4, 1),
    (5, 2, 1, 1),
    (6, 2, 2, 1),
    (7, 2, 3, 1),
    (8, 2, 4, 1),
    (9, 3, 1, 1),
    (10, 3, 2, 1),
    (11, 3, 3, 1),
    (12, 3, 4, 1),
    (13, 3, 5, 1),
    (14, 3, 6, 1),
    (15, 3, 7, 1),
    (16, 3, 8, 1),
    (17, 3, 9, 1),
    (18, 3, 10, 1);

