-- Insertar productoras
INSERT INTO productora (nombre) VALUES 
('EA'),
('Respawn'),
('EpicGames'),
('Ubisoft'),
('Activision'),
('Rockstar Games');

-- Insertar categorías
INSERT INTO categoria (nombre) VALUES 
('Acción'),
('Aventura'),
('Deportes'),
('Estrategia'),
('RPG'),
('Simulación');

-- Insertar videojuegos
INSERT INTO videojuego (titulo, productoraId, categoriaId, fecha_lanzamiento, precio, imagen) VALUES 
('FIFA 23', 1, 3, '2023-09-28', 59.99, 'assets/imagenes/videojuegos/Fifa23.jpg'),
('Battlefield 2042', 1, 1, '2021-10-22', 69.99, 'assets/imagenes/videojuegos/Battlefield2042.jpg'),
('Apex Legends', 2, 1, '2019-02-04', 0, 'assets/imagenes/videojuegos/ApexLegends.jpg'),
('Fortnite', 3, 1, '2017-07-25', 0, 'assets/imagenes/videojuegos/Fortnite.jpg'),
('Assassin''s Creed Valhalla', 4, 5, '2020-11-10', 59.99, 'assets/imagenes/videojuegos/AssassinsCreedValhalla.jpg'),
('Call of Duty: Modern Warfare', 5, 1, '2019-10-25', 59.99, 'assets/imagenes/videojuegos/CODModernWarfare.jpg'),
('Grand Theft Auto V', 6, 1, '2013-09-17', 29.99, 'assets/imagenes/videojuegos/GTAV.jpg'),
('Super Mario Odyssey', 1, 1, '2017-10-27', 59.99, 'assets/imagenes/videojuegos/SuperMarioOdyssey.jpg'),
('The Legend of Zelda: Breath of the Wild', 1, 1, '2017-03-03', 59.99, 'assets/imagenes/videojuegos/ZeldaBreathWild.jpg'),
('God of War', 2, 3, '2018-04-20', 39.99, 'assets/imagenes/videojuegos/GodOfWar.jpg'),
('Horizon Zero Dawn', 2, 4, '2017-02-28', 19.99, 'assets/imagenes/videojuegos/HorizonZeroDawn.jpg'),
('Halo 5: Guardians', 3, 2, '2015-10-27', 39.99, 'assets/imagenes/videojuegos/Halo5Guardians.jpg'),
('Gears of War 4', 3, 2, '2016-10-11', 19.99, 'assets/imagenes/videojuegos/GearsOfWar4.jpg'),
('Final Fantasy VII Remake', 4, 3, '2020-04-10', 59.99, 'assets/imagenes/videojuegos/FinalFantasyVII.jpg'),
('Cyberpunk 2077', 5, 3, '2020-12-10', 59.99, 'assets/imagenes/videojuegos/Cyberpunk2077.jpg'),
('The Elder Scrolls V: Skyrim', 6, 3, '2011-11-11', 19.99, 'assets/imagenes/videojuegos/Skyrim.jpg');