-- 1. Borrar la base de datos si ya existía para empezar desde cero
DROP DATABASE IF EXISTS gimnasio_db;

-- 2. Crear la base de datos
CREATE DATABASE gimnasio_db
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_spanish_ci;

-- 3. Decirle a HeidiSQL que use esta base de datos a partir de ahora
USE gimnasio_db;

-- 4. Creación de la tabla roles
CREATE TABLE roles (
    id_rol INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL UNIQUE,
    descripcion VARCHAR(150) NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 5. Creación de la tabla tipos_membresia
CREATE TABLE tipos_membresia (
    id_tipo INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    precio DECIMAL(10,2) NOT NULL,
    duracion_dias SMALLINT NOT NULL,
    incluye_clases TINYINT(1) NOT NULL DEFAULT 1,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_precio CHECK (precio >= 0), 
    CONSTRAINT chk_duracion_dias CHECK (duracion_dias > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 6. Creación de la tabla salas
CREATE TABLE salas (
    id_sala INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL UNIQUE,
    capacidad SMALLINT NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_sala_capacidad CHECK (capacidad > 0) 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 7. Creación de la tabla actividades
CREATE TABLE actividades (
    id_actividad INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    duracion_min SMALLINT NOT NULL,
    cupo_maximo SMALLINT NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
	 CONSTRAINT chk_act_duracion CHECK (duracion_min > 0),
	 CONSTRAINT chk_act_cupo CHECK (cupo_maximo > 0)  
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 8. Creación de la tabla socios
CREATE TABLE socios (
    id_socio INT AUTO_INCREMENT PRIMARY KEY,
    cedula VARCHAR(16) NOT NULL UNIQUE,
    nombres VARCHAR(60) NOT NULL,
    apellidos VARCHAR(60) NOT NULL,
    fecha_nacimiento DATE NULL,
    genero ENUM('F', 'M') NULL,
    telefono VARCHAR(15) NULL,
    correo VARCHAR(100) NULL,
    direccion VARCHAR(200) NULL,
    fecha_registro DATE NOT NULL DEFAULT (CURRENT_DATE),
    activo TINYINT(1) NOT NULL DEFAULT 1
 ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 9. Creación de la tabla instructores
CREATE TABLE instructores (
    id_instructor INT AUTO_INCREMENT PRIMARY KEY,
    cedula VARCHAR(16) NOT NULL UNIQUE,
    nombres VARCHAR(60) NOT NULL,
    apellidos VARCHAR(60) NOT NULL,
    especialidad VARCHAR(60) NULL,
    telefono VARCHAR(15) NULL,
    correo VARCHAR(100) NULL,
    fecha_contratacion DATE NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 10. Creación de la tabla usuarios
CREATE TABLE usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(40) NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL,
    sal VARCHAR(64) NOT NULL,
    id_rol INT NOT NULL,
    id_socio INT NULL UNIQUE,       
    id_instructor INT NULL UNIQUE,  
    intentos_fallidos TINYINT NOT NULL DEFAULT 0,
    activo TINYINT(1) NOT NULL DEFAULT 1, 
    ultimo_acceso DATETIME NULL,
    CONSTRAINT fk_usu_rol FOREIGN KEY (id_rol)
    REFERENCES roles(id_rol) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_usu_socio FOREIGN KEY (id_socio)
    REFERENCES socios(id_socio) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_usu_instructor FOREIGN KEY (id_instructor)
    REFERENCES instructores(id_instructor) ON UPDATE CASCADE ON DELETE RESTRICT    
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 11. Creación de la tabla bitacora_accesos
CREATE TABLE bitacora_accesos (
    id_bitacora INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NULL,            
    usuario_intento VARCHAR(40) NOT NULL,
    fecha_hora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    resultado ENUM('Exitoso', 'Fallido', 'Bloqueado') NOT NULL,
    equipo VARCHAR(60) NULL,
    CONSTRAINT fk_bit_usuario FOREIGN KEY (id_usuario) 
        REFERENCES usuarios(id_usuario) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 12. Creación de la tabla membresias
CREATE TABLE membresias (
    id_membresia INT AUTO_INCREMENT PRIMARY KEY,
    id_socio INT NOT NULL,
    id_tipo INT NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    precio_pactado DECIMAL(10,2) NOT NULL,
    estado ENUM('Activa', 'Vencida', 'Suspendida', 'Cancelada') NOT NULL DEFAULT 'Activa',
    CONSTRAINT chk_mem_fechas CHECK (fecha_vencimiento >= fecha_inicio), 
    CONSTRAINT chk_precio_pactado CHECK (precio_pactado >= 0),  
    CONSTRAINT fk_mem_socio FOREIGN KEY (id_socio) 
        REFERENCES socios(id_socio) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_mem_tipo FOREIGN KEY (id_tipo) 
        REFERENCES tipos_membresia(id_tipo) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 13. Creación de la tabla pagos 
CREATE TABLE pagos (
    id_pago INT AUTO_INCREMENT PRIMARY KEY,
    id_membresia INT NOT NULL,
    id_usuario_registro INT NOT NULL,             
    monto DECIMAL(10,2) NOT NULL,                  
    metodo_pago ENUM('Efectivo', 'Tarjeta', 'Transferencia') NOT NULL,             
    referencia VARCHAR(50) NULL,                   
    observacion VARCHAR(200) NULL,                 
    fecha_pago DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    anulado TINYINT(1) NOT NULL DEFAULT 0,        
    CONSTRAINT chk_pago_monto CHECK (monto > 0),   
    CONSTRAINT fk_pago_membresia FOREIGN KEY (id_membresia) 
        REFERENCES membresias(id_membresia) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_pago_usuario FOREIGN KEY (id_usuario_registro) 
        REFERENCES usuarios(id_usuario) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 14. Creación de la tabla horarios
CREATE TABLE horarios (
    id_horario INT AUTO_INCREMENT PRIMARY KEY,
    id_instructor INT NOT NULL,
    id_actividad INT NOT NULL,
    id_sala INT NOT NULL,
    dia_semana TINYINT NOT NULL,
    hora_inicio TIME NOT NULL,
    hora_fin TIME NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_hor_dia CHECK (dia_semana BETWEEN 1 AND 7),
    CONSTRAINT chk_hor_horas CHECK (hora_fin > hora_inicio),
    CONSTRAINT fk_hor_instructor FOREIGN KEY (id_instructor)
        REFERENCES instructores(id_instructor) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_hor_actividad FOREIGN KEY (id_actividad)
        REFERENCES actividades(id_actividad) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_hor_sala FOREIGN KEY (id_sala)
        REFERENCES salas(id_sala) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;


-- =============================================================================
-- INSERCIÓN DE DATOS DE PRUEBA MÍNIMOS
-- =============================================================================

-- 1. ROLES
INSERT INTO roles (nombre, descripcion) VALUES
('Administrador', 'Acceso total al sistema, configuraciones avanzadas y reportes globales.'),
('Recepcionista', 'Gestión diaria de socios, inscripciones, membresías y cobro de pagos.'),
('Instructor', 'Asignación de salas, control de actividades y consulta de horarios.'),
('Socio', 'Acceso exclusivo al portal personal para ver vigencia de membresía.');

-- 2. TIPOS DE MEMBRESÍA
INSERT INTO tipos_membresia (nombre, descripcion, precio, duracion_dias, incluye_clases) VALUES
('Pase Diario', 'Acceso por un único día a la sala de pesas.', 80.00, 1, 0),
('Semanal', 'Acceso libre total por 7 días calendario.', 250.00, 7, 1),
('Mensual', 'Acceso total por 30 días con uso de salas incluido.', 800.00, 30, 1),
('Trimestral', 'Plan de 90 días.', 2200.00, 90, 1),
('Anual', 'Plan completo de 365 días.', 7800.00, 365, 1);

-- 3. SALAS
INSERT INTO salas (nombre, capacidad) VALUES
('Sala Principal de Pesas', 50),
('Salón de Aeróbicos y Zumba', 20),
('Área de Boxeo y Funcionales', 15);

-- 4. ACTIVIDADES
INSERT INTO actividades (nombre, descripcion, duracion_min, cupo_maximo) VALUES
('Zumba Fitness', 'Clase de baile rítmico aeróbico.', 60, 20),
('Spinning Intensivo', 'Entrenamiento cardiovascular en bicicleta estática.', 45, 15),
('Boxeo Funcional', 'Técnicas de combate combinadas con alta intensidad.', 60, 12),
('Yoga y Estiramiento', 'Sesión de relajación, flexibilidad y respiración.', 50, 15),
('CrossFit Principiantes', 'Rutinas de fuerza y acondicionamiento metabólico.', 60, 10);

-- 5. INSTRUCTORES
INSERT INTO instructores (cedula, nombres, apellidos, especialidad, telefono, correo, fecha_contratacion, activo) VALUES
('001-150890-1002Q', 'Harold Yoel', 'Reyes Lanuza', 'Musculación y CrossFit', '8877-6655', 'harold.reyes@titan.com', '2024-01-15', 1),
('161-120495-1000A', 'Ana Gabriela', 'Espinoza Torrez', 'Zumba y Ritmos Latinos', '7766-5544', 'ana.espinoza@titan.com', '2024-06-01', 1),
('002-231188-1004F', 'Luis Fernando', 'Gaitán Blandón', 'Spinning y Cardio Intensivo', '8554-3322', 'luis.gaitan@titan.com', '2025-02-20', 1),
('441-050793-1001M', 'Martha Cecilia', 'Gutiérrez Vega', 'Yoga y Pilates Clínico', '7554-1122', 'martha.gutierrez@titan.com', '2025-09-10', 1);

-- 6. SOCIOS
INSERT INTO socios (cedula, nombres, apellidos, fecha_nacimiento, genero, telefono, correo, direccion, activo) VALUES
('001-120598-1001A', 'Franklin Alexis', 'Pérez López', '1998-05-12', 'M', '8888-1111', 'franklin.perez@email.com', 'Barrio Central, Estelí', 1),
('161-240895-1002B', 'Genesis Sharon', 'Conde Bucardo', '1995-08-24', 'F', '8777-2222', 'genesis.conde@email.com', 'Villa Fontana, Managua', 1),
('002-140290-1003C', 'Pedro Antonio', 'Torrez Blandón', '1990-02-14', 'M', '8666-3333', 'pedro.torrez@email.com', 'Bello Horizonte, Managua', 1),
('441-030999-1004D', 'Laura Sofía', 'Martínez Vega', '1999-09-03', 'F', '8555-4444', 'laura.martinez@email.com', 'Barrio El Rosario, Esteli', 1),
('001-301192-1005E', 'José Luis', 'Rodríguez Cruz', '1992-11-30', 'M', '8444-5555', 'jose.rodriguez@email.com', 'Reparto Schick, Managua', 1),
('161-150794-1006F', 'Andrea Carolina', 'Espinoza Díaz', '1994-07-15', 'F', '8333-6666', 'andrea.espinoza@email.com', 'Colonia Centroamérica, Managua', 1),
('002-050487-1007G', 'Manuel Jose', 'Gaitán Silva', '1987-04-05', 'M', '8222-7777', 'manuel.gaitan@email.com', 'Barrio San Judas, Managua', 1),
('441-221096-1008H', 'Claudia María', 'Gutiérrez Solís', '1996-10-22', 'F', '8111-8888', 'claudia.gutierrez@email.com', 'Altamira, Managua', 1),
('001-180191-1009I', 'Roberto Carlos', 'Ramírez Ortiz', '1991-01-18', 'M', '7888-9999', 'roberto.ramirez@email.com', 'Linda Vista, Managua', 1),
('161-090693-1010J', 'Elena Beatriz', 'Castro Zelaya', '1993-06-09', 'F', '7777-1111', 'elena.castro@email.com', 'Los Robles, Managua', 1),
('002-270389-1011K', 'Francisco Javier', 'Núñez Gutierrez', '1989-03-27', 'M', '7666-2222', 'francisco.nunez@email.com', 'Ciudad Jardín, Managua', 1),
('441-111197-1012L', 'Diana Marcela', 'Sequeira Morales', '1997-11-11', 'F', '7555-3333', 'diana.sequeira@email.com', 'Las Brisas, Managua', 1),
('001-020894-1013M', 'Carlos Danilo', 'Hernández Mairena', '1994-08-02', 'M', '7444-4444', 'carlos.hernandez@email.com', 'La chiriza, Estelí', 1),
-- Los siguientes 2 socios están inactivos (activo = 0)
('161-191292-1014N', 'Gabriela Alejandra', 'Vargas Jirón', '1992-12-19', 'F', '7333-5555', 'gabriela.vargas@email.com', 'Ruben Dario, Esteli', 0),
('002-250591-1015P', 'Luis Armando', 'Mendoza Castillo', '1991-05-25', 'M', '7222-6666', 'luis.mendoza@email.com', 'Sutiaba, León', 0);

-- 7. INSERTAR USUARIOS 
INSERT INTO usuarios (nombre_usuario, contrasena_hash, sal, id_rol, id_socio, id_instructor, intentos_fallidos, activo, ultimo_acceso) VALUES
('admi01', 'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 'sal_aleatoria_admin_1234567890abcdef', 1, NULL, NULL, 0, 1, NULL), 
('recep01', '8544e66298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 'sal_aleatoria_recep_1234567890abcdef', 2, NULL, NULL, 0, 1, NULL), 
('instructor01', '7433e66298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 'sal_aleatoria_train_1234567890abcdef', 3, NULL, 1, 0, 1, NULL),             
('socio_user01', '6322e66298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 'sal_aleatoria_socio_1234567890abcdef', 4, NULL, NULL, 0, 1, NULL),            
('recep02', '5211e66298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 'sal_aleatoria_recep2_1234567890abcdef', 2, NULL, NULL, 0, 1, NULL),             
-- Cuenta Bloqueada (aquí sí ponemos fecha porque ya se usó e intentaron entrar por la fuerza)
('usuario_bloqueado', '0000e66298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 'sal_bloqueada_1234567890abcdef', 2, NULL, NULL, 3, 0, '2026-09-15 14:20:00');

-- 8. INSERTAR MEMBRESIAS (15)
INSERT INTO membresias (id_socio, id_tipo, fecha_inicio, fecha_vencimiento, precio_pactado, estado) VALUES
-- 3 MEMBRESÍAS VENCIDAS
(1, 3, '2026-08-01', '2026-08-31', 800.00, 'Vencida'),   
(2, 2, '2026-08-10', '2026-08-17', 250.00, 'Vencida'),   
(3, 1, '2026-09-05', '2026-09-06', 80.00, 'Vencida'),    

-- 3 MEMBRESÍAS POR VENCER EN LOS PRÓXIMOS 7 DÍAS (Su estado oficial es 'Activa')
(4, 3, '2026-09-01', '2026-10-01', 800.00, 'Activa'),    -- Vence el 1 de Octubre
(5, 3, '2026-09-03', '2026-10-03', 800.00, 'Activa'),    -- Vence el 3 de Octubre
(6, 3, '2026-09-05', '2026-10-05', 800.00, 'Activa'),    -- Vence el 5 de Octubre

-- 9 MEMBRESÍAS ACTIVAS RESTANTES
(7, 3, '2026-09-15', '2026-10-15', 800.00, 'Activa'),     
(8, 4, '2026-08-01', '2026-10-30', 2200.00, 'Activa'),    
(9, 5, '2026-01-15', '2027-01-15', 7800.00, 'Activa'),    
(10, 3, '2026-09-20', '2026-10-20', 800.00, 'Activa'),    
(11, 3, '2026-09-25', '2026-10-25', 800.00, 'Activa'),    
(12, 4, '2026-09-01', '2026-12-01', 2200.00, 'Activa'),    
(13, 2, '2026-09-28', '2026-10-05', 250.00, 'Activa'),    
(14, 3, '2026-09-10', '2026-10-10', 800.00, 'Activa'),    
(15, 3, '2026-09-12', '2026-10-12', 800.00, 'Activa');

-- 9. INSERTAR PAGOS (incluyendo abonos parciales y 1 pago anulado)
INSERT INTO pagos (id_membresia, id_usuario_registro, monto, fecha_pago, metodo_pago, referencia, observacion, anulado) VALUES
-- Membresía 1 (Mensual C$800 - Cancelada en dos abonos parciales de C$400)
(1, 2, 400.00, '2026-08-01 09:00:00', 'Efectivo', NULL, 'Primer abono mensual', 0),
(1, 2, 400.00, '2026-08-15 17:30:00', 'Efectivo', NULL, 'Segundo abono para cancelar', 0),

-- Membresía 2 (Semanal C$250 - Pagado completo)
(2, 2, 250.00, '2026-08-10 08:00:00', 'Efectivo', NULL, 'Pago completo semanal', 0),

-- Membresía 3 (Diario C$80 - Pagado completo)
(3, 2, 80.00, '2026-09-05 10:20:00', 'Efectivo', NULL, 'Pase diario', 0),

-- Membresía 4 (Mensual C$800 - Tiene un abono parcial de C$500, saldo pendiente C$300)
(4, 2, 500.00, '2026-09-01 07:45:00', 'Tarjeta', 'REC-99401', 'Abono inicial de membresía', 0),

-- Membresía 5 (Mensual C$800 - Pagado completo)
(5, 2, 800.00, '2026-09-03 11:15:00', 'Transferencia', 'TX-88401', 'Pago completo mensual', 0),

-- Membresía 6 (Mensual C$800 - Pagado completo)
(6, 2, 800.00, '2026-09-05 16:00:00', 'Efectivo', NULL, 'Pago mensual', 0),

-- Membresía 7 (Mensual C$800 - Pagado completo)
(7, 2, 800.00, '2026-09-15 14:00:00', 'Tarjeta', 'REC-99455', 'Pago mensual', 0),

-- Membresía 8 (Trimestral C$2200 - Pagado en dos abonos parciales)
(8, 2, 1200.00, '2026-08-01 09:30:00', 'Transferencia', 'TX-10022', 'Primer abono trimestral', 0),
(8, 2, 1000.00, '2026-09-01 10:00:00', 'Efectivo', NULL, 'Segundo abono trimestral saldo', 0),

-- Membresía 9 (Anual C$7800 - Pagado completo)
(9, 2, 7800.00, '2026-01-15 08:30:00', 'Transferencia', 'TX-00125', 'Pago anual completo', 0),

-- Membresías de la 10 a la 18 (Pagos completos individuales)
(10, 2, 800.00, '2026-09-20 09:15:00', 'Efectivo', NULL, 'Pago mensual', 0),
(11, 2, 800.00, '2026-09-25 11:40:00', 'Tarjeta', 'REC-99500', 'Pago mensual', 0),
(12, 2, 2200.00, '2026-09-01 15:20:00', 'Transferencia', 'TX-10544', 'Pago trimestral', 0),
(13, 2, 250.00, '2026-09-28 07:10:00', 'Efectivo', NULL, 'Pago semanal', 0),
(14, 2, 800.00, '2026-09-10 12:00:00', 'Efectivo', NULL, 'Pago mensual', 0),
(15, 2, 800.00, '2026-09-12 10:30:00', 'Efectivo', NULL, 'Pago mensual', 0),

-- Pagos extras
(10, 2, 800.00, '2026-09-21 08:00:00', 'Efectivo', NULL, 'Pago extra de prueba', 0),
(11, 2, 800.00, '2026-09-22 09:30:00', 'Efectivo', NULL, 'Pago extra de prueba 2', 0),
(12, 2, 2200.00, '2026-09-23 14:00:00', 'Efectivo', NULL, 'Pago extra de prueba 3', 0),

-- Este pago fue anulado (anulado = 1) por error en digitación de tarjeta
(5, 2, 800.00, '2026-09-03 11:00:00', 'Tarjeta', 'REC-00000', 'ERROR - PAGO ANULADO POR DUPLICADO', 1);

-- 10. INSERTAR HORARIOS (15 distribuidos de lunes a sabado sin choques)
INSERT INTO horarios (id_instructor, id_actividad, id_sala, dia_semana, hora_inicio, hora_fin, activo) VALUES
-- LUNES (Día 1) 
(1, 5, 1, 1, '06:00:00', '07:00:00', 1), 
(2, 1, 2, 1, '08:00:00', '09:00:00', 1), 
(3, 2, 3, 1, '18:00:00', '18:45:00', 1), 

-- MARTES (Día 2)
(4, 4, 2, 2, '07:00:00', '07:50:00', 1), 
(1, 3, 3, 2, '17:00:00', '18:00:00', 1), 
(3, 2, 1, 2, '19:00:00', '19:45:00', 1), 

-- MIERCOLES (Día 3)
(1, 5, 1, 3, '06:00:00', '07:00:00', 1), 
(2, 1, 2, 3, '08:00:00', '09:00:00', 1), 
(4, 4, 2, 3, '18:00:00', '18:50:00', 1), 

-- JUEVES (Día 4)
(1, 3, 3, 4, '17:00:00', '18:00:00', 1), 
(2, 1, 2, 4, '19:00:00', '20:00:00', 1), 

-- VIERNES (Día 5)
(3, 2, 1, 5, '06:30:00', '07:15:00', 1), 
(4, 4, 2, 5, '08:00:00', '08:50:00', 1), 

-- SABADO (Día 6) 
(1, 5, 1, 6, '09:00:00', '10:00:00', 1), 
(2, 1, 2, 6, '11:00:00', '12:00:00', 1);



-- =============================================================================
-- CONTROL DE ACCESO EN EL SERVIDOR 
-- =============================================================================

-- Creamos el usuario exclusivo para la aplicación
CREATE USER IF NOT EXISTS 'gym_app'@'localhost' IDENTIFIED BY 'Gym#2026app';

-- Le asignamos únicamente los permisos requeridos sobre la base de datos
GRANT SELECT, INSERT, UPDATE, DELETE ON gimnasio_db.* TO 'gym_app'@'localhost';

-- Aplicamos los cambios de permisos en el servidor de MariaDB
FLUSH PRIVILEGES;

