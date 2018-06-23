-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 23, 2018 at 04:41 AM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bd-les`
--
CREATE DATABASE IF NOT EXISTS `bd-les` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bd-les`;

-- --------------------------------------------------------

--
-- Table structure for table `agente_trat`
--

DROP TABLE IF EXISTS `agente_trat`;
CREATE TABLE `agente_trat` (
  `idAgenTra` int(11) NOT NULL,
  `nomeAgenTra` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `agente_trat`
--

INSERT INTO `agente_trat` (`idAgenTra`, `nomeAgenTra`) VALUES
(1, 'OxAquaculture (em 500 L)');

-- --------------------------------------------------------

--
-- Table structure for table `circuito_tanque`
--

DROP TABLE IF EXISTS `circuito_tanque`;
CREATE TABLE `circuito_tanque` (
  `idCircuito` int(11) NOT NULL,
  `Projeto_idProjeto` int(11) NOT NULL,
  `codigoCircuito` varchar(15) DEFAULT NULL,
  `dataCriacao` datetime NOT NULL,
  `dataFinal` datetime NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `circuito_tanque`
--

INSERT INTO `circuito_tanque` (`idCircuito`, `Projeto_idProjeto`, `codigoCircuito`, `dataCriacao`, `dataFinal`, `isarchived`) VALUES
(1, 1, '234234', '2018-05-21 00:00:00', '2018-05-21 00:00:00', 1),
(2, 2, 'rsdfgsdfg', '2018-05-29 00:00:00', '2018-05-29 00:00:00', 1),
(3, 1, 'teste CT', '2018-06-23 00:00:00', '2018-06-30 00:00:00', 0);

-- --------------------------------------------------------

--
-- Table structure for table `conselho`
--

DROP TABLE IF EXISTS `conselho`;
CREATE TABLE `conselho` (
  `id` int(11) NOT NULL,
  `nomeConselho` varchar(45) NOT NULL,
  `Distrito_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `distrito`
--

DROP TABLE IF EXISTS `distrito`;
CREATE TABLE `distrito` (
  `id` int(11) NOT NULL,
  `nomeDistrito` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `elementoequipa`
--

DROP TABLE IF EXISTS `elementoequipa`;
CREATE TABLE `elementoequipa` (
  `idElementoEquipa` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `função` varchar(40) NOT NULL,
  `Projeto_idProjeto` int(11) NOT NULL,
  `Funcionario_idFuncionario` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `elementoequipa`
--

INSERT INTO `elementoequipa` (`idElementoEquipa`, `Nome`, `função`, `Projeto_idProjeto`, `Funcionario_idFuncionario`) VALUES
(11, 'teste', 'bananas no outro projeto', 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `ensaio`
--

DROP TABLE IF EXISTS `ensaio`;
CREATE TABLE `ensaio` (
  `idEnsaio` int(11) NOT NULL,
  `dataInicio` datetime NOT NULL,
  `dataFim` datetime NOT NULL,
  `descTratamento` varchar(45) NOT NULL,
  `grauSeveridade` int(11) NOT NULL,
  `Projeto_idProjeto` int(11) NOT NULL,
  `Lote_idLote` int(11) NOT NULL,
  `membroEquipa_idEquipa` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ensaio`
--

INSERT INTO `ensaio` (`idEnsaio`, `dataInicio`, `dataFim`, `descTratamento`, `grauSeveridade`, `Projeto_idProjeto`, `Lote_idLote`, `membroEquipa_idEquipa`, `isarchived`) VALUES
(1, '2018-05-09 00:00:00', '2018-05-09 00:00:00', '23424', 234243, 1, 1, 23423, 0),
(2, '2018-05-29 00:00:00', '2018-05-29 00:00:00', 'gfhfgh', 56, 1, 1, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `especie`
--

DROP TABLE IF EXISTS `especie`;
CREATE TABLE `especie` (
  `idEspecie` int(11) NOT NULL,
  `NomeCient` varchar(45) DEFAULT NULL,
  `NomeVulgar` varchar(45) DEFAULT NULL,
  `Familia_idFamilia` int(11) NOT NULL,
  `Familia_Grupo_idGrupo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `familia`
--

DROP TABLE IF EXISTS `familia`;
CREATE TABLE `familia` (
  `idFamilia` int(11) NOT NULL,
  `Grupo_idGrupo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `finalidade`
--

DROP TABLE IF EXISTS `finalidade`;
CREATE TABLE `finalidade` (
  `idFinalidade` int(11) NOT NULL,
  `T_Finalidade` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `finalidade`
--

INSERT INTO `finalidade` (`idFinalidade`, `T_Finalidade`) VALUES
(1, 'Eliminar Eczema');

-- --------------------------------------------------------

--
-- Table structure for table `fornecedorcolector`
--

DROP TABLE IF EXISTS `fornecedorcolector`;
CREATE TABLE `fornecedorcolector` (
  `idFornColect` int(11) NOT NULL,
  `Tipo` char(1) NOT NULL,
  `Nome` varchar(45) DEFAULT NULL,
  `NIF` int(10) DEFAULT NULL,
  `nroLicenca` int(11) DEFAULT NULL,
  `Morada` varchar(45) DEFAULT NULL,
  `telefone` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
CREATE TABLE `funcionario` (
  `idFuncionario` int(11) NOT NULL,
  `nomeCompleto` varchar(45) NOT NULL,
  `nomeUtilizador` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `telefone` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `funcionario`
--

INSERT INTO `funcionario` (`idFuncionario`, `nomeCompleto`, `nomeUtilizador`, `password`, `telefone`) VALUES
(1, 'bananas', 'bananas', 'bananas', 'bananas'),
(2, 'morangos', 'morangos', 'morangos', 'morangos');

-- --------------------------------------------------------

--
-- Table structure for table `grupo`
--

DROP TABLE IF EXISTS `grupo`;
CREATE TABLE `grupo` (
  `idGrupo` int(11) NOT NULL,
  `NomeGrupo` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `localcaptura`
--

DROP TABLE IF EXISTS `localcaptura`;
CREATE TABLE `localcaptura` (
  `idLocalCaptura` int(11) NOT NULL,
  `Localidade` varchar(45) DEFAULT NULL,
  `Latitude` float(10,6) DEFAULT NULL,
  `Longitude` float(10,6) DEFAULT NULL,
  `Conselho_id` int(11) NOT NULL,
  `Conselho_Distrito_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `lote`
--

DROP TABLE IF EXISTS `lote`;
CREATE TABLE `lote` (
  `idLote` int(11) NOT NULL,
  `codigoLote` varchar(10) NOT NULL,
  `dataInicio` datetime NOT NULL,
  `dataFim` datetime DEFAULT NULL,
  `Observacoes` varchar(45) DEFAULT NULL,
  `Reg_Novos_Animais_idRegAnimal` int(11) NOT NULL,
  `Funcionario_idFuncionario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `lote`
--

INSERT INTO `lote` (`idLote`, `codigoLote`, `dataInicio`, `dataFim`, `Observacoes`, `Reg_Novos_Animais_idRegAnimal`, `Funcionario_idFuncionario`) VALUES
(1, '13235', '2018-05-24 00:00:00', '2018-05-26 00:00:00', 'balhelhas', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `lote_sub_lote`
--

DROP TABLE IF EXISTS `lote_sub_lote`;
CREATE TABLE `lote_sub_lote` (
  `Lote_idLote_prev` int(11) NOT NULL,
  `Lote_idLote_atual` int(11) NOT NULL,
  `codigoSubLote` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `motivo`
--

DROP TABLE IF EXISTS `motivo`;
CREATE TABLE `motivo` (
  `idMotivo` int(11) NOT NULL,
  `tipoMotivo` varchar(45) NOT NULL,
  `nomeMotivo` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `motivo`
--

INSERT INTO `motivo` (`idMotivo`, `tipoMotivo`, `nomeMotivo`) VALUES
(1, 'doença', 'faleceu de gonorreia');

-- --------------------------------------------------------

--
-- Table structure for table `origem`
--

DROP TABLE IF EXISTS `origem`;
CREATE TABLE `origem` (
  `idOrigem` int(11) NOT NULL,
  `TipoOrigem` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `plano_alimentar`
--

DROP TABLE IF EXISTS `plano_alimentar`;
CREATE TABLE `plano_alimentar` (
  `idPlanAlim` int(11) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `MarcaAlim` varchar(45) DEFAULT NULL,
  `Tipo` int(11) NOT NULL,
  `Temperatura` float NOT NULL,
  `Racao` float DEFAULT NULL,
  `RacaoDia` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `plano_alimentar`
--

INSERT INTO `plano_alimentar` (`idPlanAlim`, `Nome`, `MarcaAlim`, `Tipo`, `Temperatura`, `Racao`, `RacaoDia`) VALUES
(1, 'morangos', 'morangos', 3, 452, 123123, 231);

-- --------------------------------------------------------

--
-- Table structure for table `projeto`
--

DROP TABLE IF EXISTS `projeto`;
CREATE TABLE `projeto` (
  `idProjeto` int(11) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `dataInicio` date NOT NULL,
  `dataFim` date NOT NULL,
  `AutorizacaoDGVA` varchar(45) DEFAULT NULL,
  `RefORBEA` int(11) DEFAULT NULL,
  `SubmisInsEurop` tinyint(1) DEFAULT NULL,
  `nroAnimaisAutoriz` int(11) DEFAULT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `projeto`
--

INSERT INTO `projeto` (`idProjeto`, `Nome`, `dataInicio`, `dataFim`, `AutorizacaoDGVA`, `RefORBEA`, `SubmisInsEurop`, `nroAnimaisAutoriz`, `isarchived`) VALUES
(1, 'teste pa meter pessoas', '2018-05-09', '2018-05-09', '1', 3, 1, 2, 0),
(2, 'outro projeto', '2018-05-09', '2018-05-09', 'asdfghjk', 1234567, 1, 12345678, 0);

-- --------------------------------------------------------

--
-- Table structure for table `reg_alimentar`
--

DROP TABLE IF EXISTS `reg_alimentar`;
CREATE TABLE `reg_alimentar` (
  `idRegAlim` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `Peso` float NOT NULL,
  `Sobras` float DEFAULT NULL,
  `Plano_Alimentar_idPlanAlim` int(11) NOT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reg_alimentar`
--

INSERT INTO `reg_alimentar` (`idRegAlim`, `data`, `Peso`, `Sobras`, `Plano_Alimentar_idPlanAlim`, `Tanque_idTanque`, `isarchived`) VALUES
(1, '2018-05-22 00:00:00', 1234, 123, 1, 1, 1),
(2, '2018-05-22 00:00:00', 12314, 124123, 1, 1, 1),
(3, '2018-05-22 00:00:00', 123123, 123123, 1, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `reg_amostragens`
--

DROP TABLE IF EXISTS `reg_amostragens`;
CREATE TABLE `reg_amostragens` (
  `idRegAmo` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `pesoMedio` float NOT NULL,
  `nroIndividuos` int(11) NOT NULL,
  `pesoTotal` float NOT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reg_amostragens`
--

INSERT INTO `reg_amostragens` (`idRegAmo`, `data`, `pesoMedio`, `nroIndividuos`, `pesoTotal`, `Tanque_idTanque`, `isarchived`) VALUES
(1, '2018-05-22 00:00:00', 123, 123, 123, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `reg_cond_amb`
--

DROP TABLE IF EXISTS `reg_cond_amb`;
CREATE TABLE `reg_cond_amb` (
  `idRegCondAmb` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `temperatura` float DEFAULT NULL,
  `volAgua` float DEFAULT NULL,
  `salinidadeAgua` float DEFAULT NULL,
  `nivelO2` float DEFAULT NULL,
  `Circuito_Tanque_idCircuito` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reg_cond_amb`
--

INSERT INTO `reg_cond_amb` (`idRegCondAmb`, `data`, `temperatura`, `volAgua`, `salinidadeAgua`, `nivelO2`, `Circuito_Tanque_idCircuito`, `isarchived`) VALUES
(1, '2018-05-29 00:00:00', 12341200, 1234230, 234234, 234234, 1, 1),
(2, '2018-06-13 00:00:00', 123, 123, 123, 123, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `reg_manutencao`
--

DROP TABLE IF EXISTS `reg_manutencao`;
CREATE TABLE `reg_manutencao` (
  `idRegMan` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `Tipo_Manuntecao_idT_Manutencao` int(11) NOT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reg_manutencao`
--

INSERT INTO `reg_manutencao` (`idRegMan`, `data`, `Tipo_Manuntecao_idT_Manutencao`, `Tanque_idTanque`, `isarchived`) VALUES
(2, '2018-05-22 00:00:00', 1, 1, 1),
(3, '2018-06-23 00:00:00', 1, 4, 0);

-- --------------------------------------------------------

--
-- Table structure for table `reg_novos_animais`
--

DROP TABLE IF EXISTS `reg_novos_animais`;
CREATE TABLE `reg_novos_animais` (
  `idRegAnimal` int(11) NOT NULL,
  `nroExemplares` int(11) NOT NULL,
  `nroMachos` int(11) DEFAULT NULL,
  `nroFemeas` int(11) DEFAULT NULL,
  `Imaturos` int(11) DEFAULT NULL,
  `Juvenis` int(11) DEFAULT NULL,
  `Larvas` int(11) DEFAULT NULL,
  `Ovos` int(11) DEFAULT NULL,
  `dataNasc` datetime DEFAULT NULL,
  `idade` int(11) DEFAULT NULL,
  `pesoMedio` float DEFAULT NULL,
  `compMedio` float DEFAULT NULL,
  `DuracaoViagem` time DEFAULT NULL,
  `tempPartida` int(11) DEFAULT NULL,
  `tempChegada` int(11) DEFAULT NULL,
  `nroContentores` int(11) DEFAULT NULL,
  `tipoContentor` varchar(45) DEFAULT NULL,
  `volContentor` float DEFAULT NULL,
  `volAgua` float DEFAULT NULL,
  `nroCaixasIsoter` int(11) DEFAULT NULL,
  `nroMortosCheg` int(11) DEFAULT NULL,
  `satO2Transp` float DEFAULT NULL,
  `anestesico` float DEFAULT NULL,
  `Gelo` tinyint(1) DEFAULT NULL,
  `Adicao_O2` tinyint(1) DEFAULT NULL,
  `Arejamento` tinyint(1) DEFAULT NULL,
  `refrigeracao` tinyint(1) DEFAULT NULL,
  `sedação` tinyint(1) DEFAULT NULL,
  `respTransporte` varchar(45) DEFAULT NULL,
  `Especie_idEspecie` int(11) NOT NULL,
  `Fornecedor_idFornColect` int(11) NOT NULL,
  `T_Origem_idT_Origem` int(11) NOT NULL,
  `LocalCaptura_idLocalCaptura` int(11) DEFAULT NULL,
  `TipoEstatutoGenetico_idTipoEstatutoGenetico` int(11) NOT NULL,
  `Funcionario_idFuncionario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reg_novos_animais`
--

INSERT INTO `reg_novos_animais` (`idRegAnimal`, `nroExemplares`, `nroMachos`, `nroFemeas`, `Imaturos`, `Juvenis`, `Larvas`, `Ovos`, `dataNasc`, `idade`, `pesoMedio`, `compMedio`, `DuracaoViagem`, `tempPartida`, `tempChegada`, `nroContentores`, `tipoContentor`, `volContentor`, `volAgua`, `nroCaixasIsoter`, `nroMortosCheg`, `satO2Transp`, `anestesico`, `Gelo`, `Adicao_O2`, `Arejamento`, `refrigeracao`, `sedação`, `respTransporte`, `Especie_idEspecie`, `Fornecedor_idFornColect`, `T_Origem_idT_Origem`, `LocalCaptura_idLocalCaptura`, `TipoEstatutoGenetico_idTipoEstatutoGenetico`, `Funcionario_idFuncionario`) VALUES
(1, 223424, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2342, 23424, 234, NULL, 23423, 234234);

-- --------------------------------------------------------

--
-- Table structure for table `reg_remocoes`
--

DROP TABLE IF EXISTS `reg_remocoes`;
CREATE TABLE `reg_remocoes` (
  `idRegRemo` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `nroRemoções` int(11) DEFAULT NULL,
  `Motivo_idMotivo` int(11) NOT NULL,
  `causaMorte` varchar(255) DEFAULT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reg_remocoes`
--

INSERT INTO `reg_remocoes` (`idRegRemo`, `date`, `nroRemoções`, `Motivo_idMotivo`, `causaMorte`, `Tanque_idTanque`, `isarchived`) VALUES
(1, '2018-05-22 00:00:00', 7578, 1, 'b', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `reg_tratamento`
--

DROP TABLE IF EXISTS `reg_tratamento`;
CREATE TABLE `reg_tratamento` (
  `idRegTra` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `Tempo` int(11) NOT NULL,
  `Concentracao` float NOT NULL,
  `Finalidade_idFinalidade` int(11) NOT NULL,
  `agente_Trat_idAgenTra` int(11) NOT NULL,
  `concAgenTra` int(11) DEFAULT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reg_tratamento`
--

INSERT INTO `reg_tratamento` (`idRegTra`, `date`, `Tempo`, `Concentracao`, `Finalidade_idFinalidade`, `agente_Trat_idAgenTra`, `concAgenTra`, `Tanque_idTanque`, `isarchived`) VALUES
(1, '2018-05-21 00:00:00', 60, 100, 1, 1, NULL, 1, 1),
(2, '2018-06-23 00:00:00', 123, 123, 1, 1, NULL, 4, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tanque`
--

DROP TABLE IF EXISTS `tanque`;
CREATE TABLE `tanque` (
  `idTanque` int(11) NOT NULL,
  `codidenttanque` varchar(255) NOT NULL,
  `nroAnimais` int(11) NOT NULL,
  `sala` varchar(15) NOT NULL,
  `observacoes` varchar(45) DEFAULT NULL,
  `Lote_idLote` int(11) NOT NULL,
  `Circuito_Tanque_idCircuito` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tanque`
--

INSERT INTO `tanque` (`idTanque`, `codidenttanque`, `nroAnimais`, `sala`, `observacoes`, `Lote_idLote`, `Circuito_Tanque_idCircuito`, `isarchived`) VALUES
(1, 'C4', 234234, '234223', '4234', 1, 1, 1),
(2, 'teste identificador 2', 123123, '123123', '123123', 1, 1, 1),
(3, 'TQ1', 21, 'werwer', 'werwer', 1, 1, 1),
(4, 'teste tq 2', 123, '123', 'sfsfsf sdfgsdg s', 1, 3, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tipoestatutogenetico`
--

DROP TABLE IF EXISTS `tipoestatutogenetico`;
CREATE TABLE `tipoestatutogenetico` (
  `idTipoEstatutoGenetico` int(11) NOT NULL,
  `TipoEstatutoGeneticocol` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tipo_manuntecao`
--

DROP TABLE IF EXISTS `tipo_manuntecao`;
CREATE TABLE `tipo_manuntecao` (
  `idT_Manutencao` int(11) NOT NULL,
  `T_Manutencao` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tipo_manuntecao`
--

INSERT INTO `tipo_manuntecao` (`idT_Manutencao`, `T_Manutencao`) VALUES
(1, 'batbatatatas');

-- --------------------------------------------------------

--
-- Table structure for table `t_origem`
--

DROP TABLE IF EXISTS `t_origem`;
CREATE TABLE `t_origem` (
  `idT_Origem` int(11) NOT NULL,
  `Descrição` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agente_trat`
--
ALTER TABLE `agente_trat`
  ADD PRIMARY KEY (`idAgenTra`);

--
-- Indexes for table `circuito_tanque`
--
ALTER TABLE `circuito_tanque`
  ADD PRIMARY KEY (`idCircuito`),
  ADD KEY `fk_Circuito_Tanque_Projeto1_idx` (`Projeto_idProjeto`);

--
-- Indexes for table `conselho`
--
ALTER TABLE `conselho`
  ADD PRIMARY KEY (`id`,`Distrito_id`),
  ADD KEY `fk_Conselho_Distrito1_idx` (`Distrito_id`);

--
-- Indexes for table `distrito`
--
ALTER TABLE `distrito`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `elementoequipa`
--
ALTER TABLE `elementoequipa`
  ADD PRIMARY KEY (`idElementoEquipa`),
  ADD KEY `fk_equipaProjeto_Projeto1` (`Projeto_idProjeto`),
  ADD KEY `fk_equipaProjeto_Funcionario1` (`Funcionario_idFuncionario`);

--
-- Indexes for table `ensaio`
--
ALTER TABLE `ensaio`
  ADD PRIMARY KEY (`idEnsaio`),
  ADD KEY `fk_Ensaio_Projeto1` (`Projeto_idProjeto`),
  ADD KEY `fk_Ensaio_Lote1` (`Lote_idLote`);

--
-- Indexes for table `especie`
--
ALTER TABLE `especie`
  ADD PRIMARY KEY (`idEspecie`,`Familia_idFamilia`,`Familia_Grupo_idGrupo`),
  ADD KEY `fk_Especie_Familia1_idx` (`Familia_idFamilia`,`Familia_Grupo_idGrupo`);

--
-- Indexes for table `familia`
--
ALTER TABLE `familia`
  ADD PRIMARY KEY (`idFamilia`,`Grupo_idGrupo`),
  ADD KEY `fk_Familia_Grupo1_idx` (`Grupo_idGrupo`);

--
-- Indexes for table `finalidade`
--
ALTER TABLE `finalidade`
  ADD PRIMARY KEY (`idFinalidade`);

--
-- Indexes for table `fornecedorcolector`
--
ALTER TABLE `fornecedorcolector`
  ADD PRIMARY KEY (`idFornColect`);

--
-- Indexes for table `funcionario`
--
ALTER TABLE `funcionario`
  ADD PRIMARY KEY (`idFuncionario`);

--
-- Indexes for table `grupo`
--
ALTER TABLE `grupo`
  ADD PRIMARY KEY (`idGrupo`);

--
-- Indexes for table `localcaptura`
--
ALTER TABLE `localcaptura`
  ADD PRIMARY KEY (`idLocalCaptura`,`Conselho_id`,`Conselho_Distrito_id`),
  ADD KEY `fk_LocalCaptura_Conselho1_idx` (`Conselho_id`,`Conselho_Distrito_id`);

--
-- Indexes for table `lote`
--
ALTER TABLE `lote`
  ADD PRIMARY KEY (`idLote`),
  ADD KEY `fk_Lote_Reg_Novos_Animais1_idx` (`Reg_Novos_Animais_idRegAnimal`),
  ADD KEY `fk_Lote_Funcionario1_idx` (`Funcionario_idFuncionario`);

--
-- Indexes for table `lote_sub_lote`
--
ALTER TABLE `lote_sub_lote`
  ADD PRIMARY KEY (`Lote_idLote_prev`,`Lote_idLote_atual`),
  ADD KEY `fk_Sub_Lote_Lote1_idx` (`Lote_idLote_prev`),
  ADD KEY `fk_Sub_Lote_Lote2_idx` (`Lote_idLote_atual`);

--
-- Indexes for table `motivo`
--
ALTER TABLE `motivo`
  ADD PRIMARY KEY (`idMotivo`);

--
-- Indexes for table `origem`
--
ALTER TABLE `origem`
  ADD PRIMARY KEY (`idOrigem`);

--
-- Indexes for table `plano_alimentar`
--
ALTER TABLE `plano_alimentar`
  ADD PRIMARY KEY (`idPlanAlim`);

--
-- Indexes for table `projeto`
--
ALTER TABLE `projeto`
  ADD PRIMARY KEY (`idProjeto`);

--
-- Indexes for table `reg_alimentar`
--
ALTER TABLE `reg_alimentar`
  ADD PRIMARY KEY (`idRegAlim`),
  ADD KEY `fk_Reg_Alimentar_Plano_Alimentar1` (`Plano_Alimentar_idPlanAlim`),
  ADD KEY `fk_Reg_Alimentar_Tanque1` (`Tanque_idTanque`);

--
-- Indexes for table `reg_amostragens`
--
ALTER TABLE `reg_amostragens`
  ADD PRIMARY KEY (`idRegAmo`),
  ADD KEY `fk_Reg_Amostragens_Tanque1` (`Tanque_idTanque`);

--
-- Indexes for table `reg_cond_amb`
--
ALTER TABLE `reg_cond_amb`
  ADD PRIMARY KEY (`idRegCondAmb`),
  ADD KEY `fk_Reg_Cond_Amb_Circuito_Tanque1` (`Circuito_Tanque_idCircuito`);

--
-- Indexes for table `reg_manutencao`
--
ALTER TABLE `reg_manutencao`
  ADD PRIMARY KEY (`idRegMan`),
  ADD KEY `fk_Reg_Manutencao_Tipo_Manuntecao1` (`Tipo_Manuntecao_idT_Manutencao`),
  ADD KEY `fk_Reg_Manutencao_Tanque1` (`Tanque_idTanque`);

--
-- Indexes for table `reg_novos_animais`
--
ALTER TABLE `reg_novos_animais`
  ADD PRIMARY KEY (`idRegAnimal`),
  ADD KEY `fk_Reg_Novos_Animais_Especie1` (`Especie_idEspecie`),
  ADD KEY `fk_Reg_Novos_Animais_Fornecedor1` (`Fornecedor_idFornColect`),
  ADD KEY `fk_Reg_Novos_Animais_T_Origem1` (`T_Origem_idT_Origem`),
  ADD KEY `fk_Reg_Novos_Animais_LocalCaptura1` (`LocalCaptura_idLocalCaptura`),
  ADD KEY `fk_Reg_Novos_Animais_TipoEstatutoGenetico1` (`TipoEstatutoGenetico_idTipoEstatutoGenetico`),
  ADD KEY `fk_Reg_Novos_Animais_Funcionario1` (`Funcionario_idFuncionario`);

--
-- Indexes for table `reg_remocoes`
--
ALTER TABLE `reg_remocoes`
  ADD PRIMARY KEY (`idRegRemo`),
  ADD KEY `fk_Reg_Remocoes_Motivo1` (`Motivo_idMotivo`),
  ADD KEY `fk_Reg_Remocoes_Tanque1` (`Tanque_idTanque`);

--
-- Indexes for table `reg_tratamento`
--
ALTER TABLE `reg_tratamento`
  ADD PRIMARY KEY (`idRegTra`),
  ADD KEY `fk_Reg_Tratamento_Finalidade1` (`Finalidade_idFinalidade`),
  ADD KEY `fk_Reg_Tratamento_agente_Trat1` (`agente_Trat_idAgenTra`),
  ADD KEY `fk_Reg_Tratamento_Tanque1` (`Tanque_idTanque`);

--
-- Indexes for table `tanque`
--
ALTER TABLE `tanque`
  ADD PRIMARY KEY (`idTanque`),
  ADD KEY `fk_Tanque_Lote1_idx` (`Lote_idLote`),
  ADD KEY `fk_Tanque_Circuito_Tanque1_idx` (`Circuito_Tanque_idCircuito`);

--
-- Indexes for table `tipoestatutogenetico`
--
ALTER TABLE `tipoestatutogenetico`
  ADD PRIMARY KEY (`idTipoEstatutoGenetico`);

--
-- Indexes for table `tipo_manuntecao`
--
ALTER TABLE `tipo_manuntecao`
  ADD PRIMARY KEY (`idT_Manutencao`);

--
-- Indexes for table `t_origem`
--
ALTER TABLE `t_origem`
  ADD PRIMARY KEY (`idT_Origem`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `agente_trat`
--
ALTER TABLE `agente_trat`
  MODIFY `idAgenTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `circuito_tanque`
--
ALTER TABLE `circuito_tanque`
  MODIFY `idCircuito` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `elementoequipa`
--
ALTER TABLE `elementoequipa`
  MODIFY `idElementoEquipa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `ensaio`
--
ALTER TABLE `ensaio`
  MODIFY `idEnsaio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `especie`
--
ALTER TABLE `especie`
  MODIFY `idEspecie` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `familia`
--
ALTER TABLE `familia`
  MODIFY `idFamilia` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `finalidade`
--
ALTER TABLE `finalidade`
  MODIFY `idFinalidade` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `fornecedorcolector`
--
ALTER TABLE `fornecedorcolector`
  MODIFY `idFornColect` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `funcionario`
--
ALTER TABLE `funcionario`
  MODIFY `idFuncionario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `grupo`
--
ALTER TABLE `grupo`
  MODIFY `idGrupo` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `lote`
--
ALTER TABLE `lote`
  MODIFY `idLote` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `motivo`
--
ALTER TABLE `motivo`
  MODIFY `idMotivo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `plano_alimentar`
--
ALTER TABLE `plano_alimentar`
  MODIFY `idPlanAlim` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `projeto`
--
ALTER TABLE `projeto`
  MODIFY `idProjeto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `reg_alimentar`
--
ALTER TABLE `reg_alimentar`
  MODIFY `idRegAlim` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `reg_amostragens`
--
ALTER TABLE `reg_amostragens`
  MODIFY `idRegAmo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `reg_cond_amb`
--
ALTER TABLE `reg_cond_amb`
  MODIFY `idRegCondAmb` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `reg_manutencao`
--
ALTER TABLE `reg_manutencao`
  MODIFY `idRegMan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `reg_novos_animais`
--
ALTER TABLE `reg_novos_animais`
  MODIFY `idRegAnimal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `reg_remocoes`
--
ALTER TABLE `reg_remocoes`
  MODIFY `idRegRemo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `reg_tratamento`
--
ALTER TABLE `reg_tratamento`
  MODIFY `idRegTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `tanque`
--
ALTER TABLE `tanque`
  MODIFY `idTanque` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `tipo_manuntecao`
--
ALTER TABLE `tipo_manuntecao`
  MODIFY `idT_Manutencao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `t_origem`
--
ALTER TABLE `t_origem`
  MODIFY `idT_Origem` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `circuito_tanque`
--
ALTER TABLE `circuito_tanque`
  ADD CONSTRAINT `fk_Circuito_Tanque_Projeto1` FOREIGN KEY (`Projeto_idProjeto`) REFERENCES `projeto` (`idProjeto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `conselho`
--
ALTER TABLE `conselho`
  ADD CONSTRAINT `fk_Conselho_Distrito1` FOREIGN KEY (`Distrito_id`) REFERENCES `distrito` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `elementoequipa`
--
ALTER TABLE `elementoequipa`
  ADD CONSTRAINT `fk_equipaProjeto_Funcionario1` FOREIGN KEY (`Funcionario_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_equipaProjeto_Projeto1` FOREIGN KEY (`Projeto_idProjeto`) REFERENCES `projeto` (`idProjeto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `ensaio`
--
ALTER TABLE `ensaio`
  ADD CONSTRAINT `fk_Ensaio_Lote1` FOREIGN KEY (`Lote_idLote`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Ensaio_Projeto1` FOREIGN KEY (`Projeto_idProjeto`) REFERENCES `projeto` (`idProjeto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `especie`
--
ALTER TABLE `especie`
  ADD CONSTRAINT `fk_Especie_Familia1` FOREIGN KEY (`Familia_idFamilia`,`Familia_Grupo_idGrupo`) REFERENCES `familia` (`idFamilia`, `Grupo_idGrupo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `familia`
--
ALTER TABLE `familia`
  ADD CONSTRAINT `fk_Familia_Grupo1` FOREIGN KEY (`Grupo_idGrupo`) REFERENCES `grupo` (`idGrupo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `localcaptura`
--
ALTER TABLE `localcaptura`
  ADD CONSTRAINT `fk_LocalCaptura_Conselho1` FOREIGN KEY (`Conselho_id`,`Conselho_Distrito_id`) REFERENCES `conselho` (`id`, `Distrito_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `lote`
--
ALTER TABLE `lote`
  ADD CONSTRAINT `fk_Lote_Funcionario1` FOREIGN KEY (`Funcionario_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Lote_Reg_Novos_Animais1` FOREIGN KEY (`Reg_Novos_Animais_idRegAnimal`) REFERENCES `reg_novos_animais` (`idRegAnimal`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `lote_sub_lote`
--
ALTER TABLE `lote_sub_lote`
  ADD CONSTRAINT `fk_Sub_Lote_Lote1` FOREIGN KEY (`Lote_idLote_prev`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Sub_Lote_Lote2` FOREIGN KEY (`Lote_idLote_atual`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reg_alimentar`
--
ALTER TABLE `reg_alimentar`
  ADD CONSTRAINT `fk_Reg_Alimentar_Plano_Alimentar1` FOREIGN KEY (`Plano_Alimentar_idPlanAlim`) REFERENCES `plano_alimentar` (`idPlanAlim`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Reg_Alimentar_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reg_amostragens`
--
ALTER TABLE `reg_amostragens`
  ADD CONSTRAINT `fk_Reg_Amostragens_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reg_cond_amb`
--
ALTER TABLE `reg_cond_amb`
  ADD CONSTRAINT `fk_Reg_Cond_Amb_Circuito_Tanque1` FOREIGN KEY (`Circuito_Tanque_idCircuito`) REFERENCES `circuito_tanque` (`idCircuito`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reg_manutencao`
--
ALTER TABLE `reg_manutencao`
  ADD CONSTRAINT `fk_Reg_Manutencao_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Reg_Manutencao_Tipo_Manuntecao1` FOREIGN KEY (`Tipo_Manuntecao_idT_Manutencao`) REFERENCES `tipo_manuntecao` (`idT_Manutencao`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reg_remocoes`
--
ALTER TABLE `reg_remocoes`
  ADD CONSTRAINT `fk_Reg_Remocoes_Motivo1` FOREIGN KEY (`Motivo_idMotivo`) REFERENCES `motivo` (`idMotivo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Reg_Remocoes_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reg_tratamento`
--
ALTER TABLE `reg_tratamento`
  ADD CONSTRAINT `fk_Reg_Tratamento_Finalidade1` FOREIGN KEY (`Finalidade_idFinalidade`) REFERENCES `finalidade` (`idFinalidade`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Reg_Tratamento_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Reg_Tratamento_agente_Trat1` FOREIGN KEY (`agente_Trat_idAgenTra`) REFERENCES `agente_trat` (`idAgenTra`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `tanque`
--
ALTER TABLE `tanque`
  ADD CONSTRAINT `fk_Tanque_Circuito_Tanque1` FOREIGN KEY (`Circuito_Tanque_idCircuito`) REFERENCES `circuito_tanque` (`idCircuito`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tanque_Lote1` FOREIGN KEY (`Lote_idLote`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
