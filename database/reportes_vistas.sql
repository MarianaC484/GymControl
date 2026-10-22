-- ============================================================
-- SCRIPT DE VISTAS Y USUARIO DE CONSULTA PARA REPORTES
-- ============================================================

USE gimnasio_db;

-- 1. Vista: Detalle de Ingresos (R01, R04, R08, R09)
CREATE OR REPLACE VIEW vw_ingresos_detalle AS
SELECT 
    p.id_pago,
    p.fecha_pago AS fecha,
    CONCAT(s.nombres, ' ', s.apellidos) AS socio,
    s.cedula,
    tm.nombre AS plan,
    p.metodo_pago,
    p.monto,
    p.anulado,
    u.nombre_usuario AS registro
FROM pagos p
JOIN membresias m ON p.id_membresia = m.id_membresia
JOIN socios s ON m.id_socio = s.id_socio
JOIN tipos_membresia tm ON m.id_tipo = tm.id_tipo
JOIN usuarios u ON p.id_usuario_registro = u.id_usuario;

-- 2. Vista: Saldos de Membresía (R02, R03, R07, R08)
CREATE OR REPLACE VIEW vw_saldos_membresia AS
SELECT 
    m.id_membresia,
    CONCAT(s.nombres, ' ', s.apellidos) AS socio,
    s.telefono,
    tm.nombre AS plan,
    m.fecha_inicio AS inicio,
    m.fecha_vencimiento AS vence,
    m.precio_pactado,
    COALESCE(SUM(CASE WHEN p.anulado = 0 THEN p.monto ELSE 0 END), 0) AS pagado,
    (m.precio_pactado - COALESCE(SUM(CASE WHEN p.anulado = 0 THEN p.monto ELSE 0 END), 0)) AS saldo,
    m.estado
FROM membresias m
JOIN socios s ON m.id_socio = s.id_socio
JOIN tipos_membresia tm ON m.id_tipo = tm.id_tipo
LEFT JOIN pagos p ON m.id_membresia = p.id_membresia
GROUP BY m.id_membresia, s.nombres, s.apellidos, s.telefono, tm.nombre, m.fecha_inicio, m.fecha_vencimiento, m.precio_pactado, m.estado;

-- 3. Vista: Estado de Cuenta por Socio (R05)
CREATE OR REPLACE VIEW vw_estado_cuenta AS
SELECT 
    CONCAT(s.nombres, ' ', s.apellidos) AS socio,
    tm.nombre AS membresia,
    CONCAT(m.fecha_inicio, ' al ', m.fecha_vencimiento) AS periodo,
    m.precio_pactado,
    p.fecha_pago,
    p.monto,
    p.metodo_pago AS metodo,
    p.anulado
FROM socios s
JOIN membresias m ON s.id_socio = m.id_socio
JOIN tipos_membresia tm ON m.id_tipo = tm.id_tipo
LEFT JOIN pagos p ON m.id_membresia = p.id_membresia;

-- 4. Vista: Horario Semanal y Ocupación (R06, R08)
CREATE OR REPLACE VIEW vw_horario_semanal AS
SELECT 
    h.dia_semana AS dia,
    CASE h.dia_semana
        WHEN 1 THEN 'Lunes'
        WHEN 2 THEN 'Martes'
        WHEN 3 THEN 'Miércoles'
        WHEN 4 THEN 'Jueves'
        WHEN 5 THEN 'Viernes'
        WHEN 6 THEN 'Sábado'
        WHEN 7 THEN 'Domingo'
    END AS nombre_dia,
    h.hora_inicio,
    h.hora_fin,
    TIMESTAMPDIFF(MINUTE, h.hora_inicio, h.hora_fin) AS minutos,
    a.nombre AS actividad,
    CONCAT(i.nombres, ' ', i.apellidos) AS instructor,
    sl.nombre AS sala
FROM horarios h
JOIN actividades a ON h.id_actividad = a.id_actividad
JOIN instructores i ON h.id_instructor = i.id_instructor
JOIN salas sl ON h.id_sala = sl.id_sala;

-- ============================================================
-- CONTROL DE ACCESO: Usuario de Solo Lectura para Reportes
-- ============================================================
CREATE USER IF NOT EXISTS 'gym_reportes'@'%' IDENTIFIED BY 'reportes123';
GRANT SELECT ON gimnasio_db.* TO 'gym_reportes'@'%';
FLUSH PRIVILEGES;
