-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3307
-- Tiempo de generación: 12-06-2024 a las 19:54:02
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdtexturas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `texturas`
--

CREATE TABLE `texturas` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `cR` int(11) DEFAULT NULL,
  `cG` int(11) DEFAULT NULL,
  `cB` int(11) DEFAULT NULL,
  `colorpintar` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `texturas`
--

INSERT INTO `texturas` (`id`, `descripcion`, `cR`, `cG`, `cB`, `colorpintar`) VALUES
(1, 'ab', 254, 125, 208, 'red'),
(2, 'ab', 255, 172, 80, 'blue'),
(3, 'amarillomostaza', 255, 188, 1, 'green'),
(4, 'naranjapiel', 250, 63, 54, 'purple'),
(5, 'fondoblanco', 255, 255, 255, 'black'),
(6, 'amarillopintura', 240, 220, 12, 'brown'),
(7, 'rojopintura', 195, 9, 46, 'yellow');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `texturas`
--
ALTER TABLE `texturas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `texturas`
--
ALTER TABLE `texturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
