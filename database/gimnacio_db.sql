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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=UTF8MB4_SPANISH_CI;

-- 5. Creación de la tabla usuarios
CREATE TABLE usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(40) NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL,
    sal VARCHAR(64) NOT NULL,
    id_rol INT NOT NULL,
    id_socio INT NULL UNIQUE,       -- NULL porque el Admin o Recepcionista no son socios
    id_instructor INT NULL UNIQUE,  -- NULL porque el Admin o Recepcionista no son instructores
    intentos_fallidos TINYINT NOT NULL DEFAULT 0,
    activo TINYINT(1) NOT NULL DEFAULT 1, 
    ultimo_acceso DATETIME NULL,
    CONSTRAINT fk_usu_rol FOREIGN KEY (id_rol) 
        REFERENCES roles(id_rol) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 6. Creación de la tabla bitacora_accesos
CREATE TABLE bitacora_accesos (
    id_bitacora INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NULL,            -- NULL por si el intento fue con un usuario que no existe
    usuario_intento VARCHAR(40) NOT NULL,
    fecha_hora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    resultado ENUM('Exitoso', 'Fallido', 'Bloqueado') NOT NULL,
    equipo VARCHAR(60) NULL,
    CONSTRAINT fk_bit_usuario FOREIGN KEY (id_usuario) 
        REFERENCES usuarios(id_usuario) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=UTF8MB4_SPANISH_CI;

-- 7. Creación de la tabla socios
CREATE TABLE socios (
    id_socio INT AUTO_INCREMENT PRIMARY KEY,
    cedula VARCHAR(20) NOT NULL UNIQUE,
    nombres VARCHAR(60) NOT NULL,
    apellidos VARCHAR(60) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    genero CHAR(1) NOT NULL,
    telefono VARCHAR(20) NULL,
    correo VARCHAR(100) NULL,
    direccion VARCHAR(255) NULL,
    fecha_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_socio_genero CHECK (genero IN ('M', 'F'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=UTF8MB4_SPANISH_CI;

-- 8. Creación de la tabla tipos_membresia
CREATE TABLE tipos_membresia (
    id_tipo_membresia INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    precio DECIMAL(10,2) NOT NULL,
    duracion_dias INT NOT NULL,
    incluye_clases TINYINT(1) NOT NULL DEFAULT 1,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_precio CHECK (precio >= 0), 
    CONSTRAINT chk_duracion_dias CHECK (duracion_dias > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=UTF8MB4_SPANISH_CI;

-- 9. Creación de la tabla membresias
CREATE TABLE membresias (
    id_membresia INT AUTO_INCREMENT PRIMARY KEY,
    id_socio INT NOT NULL,
    id_tipo_membresia INT NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    precio_pactado DECIMAL(10,2) NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1, 
    CONSTRAINT chk_mem_fechas CHECK (fecha_vencimiento >= fecha_inicio), 
    CONSTRAINT chk_precio_pactado CHECK (precio_pactado >= 0),  
    CONSTRAINT fk_mem_socio FOREIGN KEY (id_socio) 
        REFERENCES socios(id_socio) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_mem_tipo FOREIGN KEY (id_tipo_membresia) 
        REFERENCES tipos_membresia(id_tipo_membresia) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=UTF8MB4_SPANISH_CI;

-- 10. Creación de la tabla pagos 
CREATE TABLE pagos (
    id_pago INT AUTO_INCREMENT PRIMARY KEY,
    id_membresia INT NOT NULL,
    id_usuario_registro INT NOT NULL,             
    monto DECIMAL(10,2) NOT NULL,                  
    metodo_pago VARCHAR(30) NOT NULL,             
    referencia VARCHAR(50) NULL,                   
    observacion VARCHAR(255) NULL,                 
    fecha_pago DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    anulado TINYINT(1) NOT NULL DEFAULT 0,        
    CONSTRAINT chk_pago_monto CHECK (monto > 0),   
    CONSTRAINT fk_pago_membresia FOREIGN KEY (id_membresia) 
        REFERENCES membresias(id_membresia) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_pago_usuario FOREIGN KEY (id_usuario_registro) 
        REFERENCES usuarios(id_usuario) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 11. Creación de la tabla instructores
CREATE TABLE instructores (
    id_instructor INT AUTO_INCREMENT PRIMARY KEY,
    cedula VARCHAR(20) NOT NULL UNIQUE,
    nombres VARCHAR(60) NOT NULL,
    apellidos VARCHAR(60) NOT NULL,
    especialidad VARCHAR(100) NULL,
    telefono VARCHAR(20) NULL,
    correo VARCHAR(100) NULL,
    fecha_contratacion DATE NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 12. Creación de la tabla actividades
CREATE TABLE actividades (
    id_actividad INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    duracion_min INT NOT NULL,
    cupo_maximo INT NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
	 CONSTRAINT chk_act_duracion CHECK (duracion_min > 0),
	 CONSTRAINT chk_act_cupo CHECK (cupo_maximo > 0)  
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- 13. Creación de la tabla salas
CREATE TABLE salas (
    id_sala INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    capacidad_max INT NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_sala_capacidad CHECK (capacidad_max > 0) 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=UTF8MB4_SPANISH_CI;

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
-- CONTROL DE ACCESO EN EL SERVIDOR 
-- =============================================================================

-- Creamos el usuario exclusivo para la aplicación
CREATE USER IF NOT EXISTS 'gym_app'@'localhost' IDENTIFIED BY 'Gym#2026app';

-- Le asignamos únicamente los permisos requeridos sobre la base de datos
GRANT SELECT, INSERT, UPDATE, DELETE ON gimnasio_db.* TO 'gym_app'@'localhost';

-- Aplicamos los cambios de permisos en el servidor de MariaDB
FLUSH PRIVILEGES;

