DELETE FROM barang;
DELETE FROM kategori;

/* -- Data Kategori -- */
INSERT INTO kategori VALUES 
('CAT001', 'Baju', 'Baju'), 
('CAT002', 'Sepatu', 'Sepatu'), 
('CAT003', 'Sandal', 'Sandal'), 
('CAT004', 'Kemeja', 'Kemeja'), 
('CAT005', 'Jas', 'Jas');

/* -- Data Barang -- */
INSERT INTO barang VALUES
('BRG001', 'Barang A', '100000', 'Info Barang A', 'default.jpg', 10, 'CAT001'),
('BRG002', 'Barang B', '120000', 'Info Barang B', 'default.jpg', 10, 'CAT001'),
('BRG003', 'Barang C', '450000', 'Info Barang C', 'default.jpg', 10, 'CAT003'),
('BRG004', 'Barang D', '250000', 'Info Barang D', 'default.jpg', 10, 'CAT002'),
('BRG005', 'Barang E', '150000', 'Info Barang E', 'default.jpg', 10, 'CAT004'),
('BRG006', 'Barang F', '610000', 'Info Barang F', 'default.jpg', 10, 'CAT005');