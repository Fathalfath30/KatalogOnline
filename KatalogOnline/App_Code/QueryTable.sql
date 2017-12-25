--
--  ______    _   _           _  __      _   _     ____   ___  
-- |  ____|  | | | |         | |/ _|    | | | |   |___ \ / _ \ 
-- | |__ __ _| |_| |__   __ _| | |_ __ _| |_| |__   __) | | | |
-- |  __/ _` | __| '_ \ / _` | |  _/ _` | __| '_ \ |__ <| | | |
-- | | | (_| | |_| | | | (_| | | || (_| | |_| | | |___) | |_| |
-- |_|  \__,_|\__|_| |_|\__,_|_|_| \__,_|\__|_| |_|____/ \___/ 
--
-- 
-- Licensed under GNU General Public License v3.0
-- http://www.gnu.org/licenses/gpl-3.0.txt
-- Written by Fathalfath30. Email : fathalfath30@gmail.com
-- Follow me on GithHub : https://github.com/Fathalfath30                                         
--                    
USE db_1512501667;
-- Menghapus dan Membuat table : kategori
DROP TABLE IF EXISTS kategori;
CREATE TABLE kategori (
	IdKat VARCHAR(7) NOT NULL,
	NmKat VARCHAR(50),
	InfoKat VARCHAR(50),
	PRIMARY KEY(IdKat)
);
INSERT INTO kategori (IdKat, NmKat, InfoKat) VALUES
('CAT0001','Kategori A','Info Kategori A'),
('CAT0002','Kategori B','Info Kategori B'),
('CAT0003','Kategori C','Info Kategori C'),
('CAT0004','Kategori D','Info Kategori D'),
('CAT0005','Kategori E','Info Kategori E');

-- Menghapus dan Membuat table : barang
DROP TABLE IF EXISTS  barang;
CREATE TABLE barang (
	KdBrg VARCHAR(7) NOT NULL,
	NmBrg VARCHAR(50),
	HrgBrg MONEY,
	InfoBrg VARCHAR(50),
	GbrBrg VARCHAR(50),
	IdKat VARCHAR(7) NOT NULL,
	StokBrg NUMERIC(3,0),
	PRIMARY KEY(KdBrg)
	-- ,CONSTRAINT FK_KATEGORI_1 FOREIGN KEY(IdKat) REFERENCES kategori(IdKat) ON UPDATE CASCADE ON DELETE CASCADE
);
INSERT INTO barang (KdBrg, NmBrg, HrgBrg, InfoBrg, GbrBrg, IdKat, StokBrg) VALUES
('BRG0001', 'Barang A', 25000, 'Info Barang A', 'default.jpg', 'CAT0001', 10),
('BRG0002', 'Barang B', 23000, 'Info Barang B', 'default.jpg', 'CAT0001', 10),
('BRG0003', 'Barang C', 21000, 'Info Barang C', 'default.jpg', 'CAT0002', 10),
('BRG0004', 'Barang D', 15000, 'Info Barang D', 'default.jpg', 'CAT0002', 10),
('BRG0005', 'Barang E', 55000, 'Info Barang E', 'default.jpg', 'CAT0003', 10),
('BRG0006', 'Barang F', 25000, 'Info Barang F', 'default.jpg', 'CAT0003', 10),
('BRG0007', 'Barang G', 35000, 'Info Barang G', 'default.jpg', 'CAT0004', 10),
('BRG0008', 'Barang H', 65000, 'Info Barang H', 'default.jpg', 'CAT0004', 10),
('BRG0009', 'Barang I', 25000, 'Info Barang I', 'default.jpg', 'CAT0005', 10),
('BRG0010', 'Barang J', 15000, 'Info Barang J', 'default.jpg', 'CAT0005', 10);

-- Menghapus dan Membuat table : pengguna
DROP TABLE IF EXISTS  pengguna;
CREATE TABLE pengguna (
	UserName VARCHAR(20) NOT NULL,
	Password VARCHAR(50),
	Nama VARCHAR(30),
	NoTelp VARCHAR(15),
	NoKartuKredit VARCHAR(16),
	Hak NCHAR(1),
	PRIMARY KEY(Username)
);

-- Menghapus dan Membuat table : pesan
DROP TABLE IF EXISTS  pesan;
CREATE TABLE pesan (
	KdPesan VARCHAR(10) NOT NULL,
	TglPesan DATETIME,
	UserName VARCHAR(20),
	PRIMARY KEY(KdPesan)
);

-- Menghapus dan Membuat table : detil_pesan
DROP TABLE IF EXISTS  detil_pesan;
CREATE TABLE detil_pesan (
	KdPesan VARCHAR(10) NOT NULL,
	KdBrg VARCHAR(7) NOT NULL,
	JmlPesan NUMERIC(3,0),
	HrgPesan MONEY,
	Subtotal VARCHAR,
	PRIMARY KEY(KdPesan, KdBrg)
);