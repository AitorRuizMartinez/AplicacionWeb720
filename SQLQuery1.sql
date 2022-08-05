CREATE TABLE participantes (
	id INT NOT NULL PRIMARY KEY IDENTITY,
	nombre  VARCHAR (50) NOT NULL,
	apellidos  VARCHAR (100) NOT NULL,
	email  VARCHAR (50) NOT NULL UNIQUE,
	telefono  INT  NOT NULL,
	fecha  INT,
	altura  INT,
	peso  INT 
	);

INSERT INTO participantes (nombre,apellidos,email,telefono,fecha,altura,peso)
VALUES
('Pedro','García Pérez','pedro@correo.es','999002002','1990','190','95'),
('María','Martínez','maria@correo.es','999003003','1980','160','55')