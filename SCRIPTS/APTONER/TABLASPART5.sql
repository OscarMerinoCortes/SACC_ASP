USE [SACCJEEN]
GO
/****** Object:  Table [dbo].[VALE_CAJA]    Script Date: 01/02/2020 13:14:13 ******/
DROP TABLE [dbo].[VALE_CAJA]
GO
/****** Object:  Table [dbo].[VALE_CAJA_DETALLE]    Script Date: 01/02/2020 13:14:13 ******/
DROP TABLE [dbo].[VALE_CAJA_DETALLE]
GO
/****** Object:  Table [dbo].[Venta_Especial]    Script Date: 01/02/2020 13:14:13 ******/
DROP TABLE [dbo].[Venta_Especial]
GO
/****** Object:  Table [dbo].[Venta_Especial]    Script Date: 01/02/2020 13:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta_Especial](
	[Numero] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](10) NULL,
	[Fecha] [datetime] NULL,
	[Cumplido] [char](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Venta_Especial] ON
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (151, N'600', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2395, N'46', CAST(0x0000AA2900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (689, N'.', CAST(0x0000A62C00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (383, N'301', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (1491, N'80', CAST(0x0000A84E00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (384, N'302', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (385, N'304', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (1384, N'222', CAST(0x0000A80200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2235, N'78', CAST(0x0000A9F200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (652, N'', CAST(0x0000A61900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (152, N'601', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2255, N'155', CAST(0x0000A9FC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (579, N'71', CAST(0x0000A5E700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (100, N'74', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2845, N'5.', CAST(0x0000AAD900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (102, N'76', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (1793, N'', CAST(0x0000A90B00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2065, N'', CAST(0x0000A99900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2184, N'106', CAST(0x0000A9D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (386, N'305', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (153, N'602', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (731, N'2222', CAST(0x0000A66300000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2073, N'', CAST(0x0000A99E00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (110, N'203', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (111, N'204', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (112, N'205', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (113, N'206', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (114, N'207', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2500, N'', CAST(0x0000AA5400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (154, N'603', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (732, N'3333', CAST(0x0000A66300000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (118, N'209', CAST(0x0000A5C200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2074, N'', CAST(0x0000A99E00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (521, N'300', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (522, N'301', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (820, N'', CAST(0x0000A68000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2185, N'107', CAST(0x0000A9D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (461, N'23242526', CAST(0x0000A5DE00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2547, N'', CAST(0x0000AA6B00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (580, N'72', CAST(0x0000A5E700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2277, N'185', CAST(0x0000AA0200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2272, N'321', CAST(0x0000AA0100000000 AS DateTime), N'1')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2284, N'178', CAST(0x0000AA0400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (155, N'604', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (156, N'605', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (157, N'606', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (158, N'607', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (159, N'608', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (160, N'609', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (161, N'610', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (162, N'611', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (163, N'612', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (164, N'613', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (165, N'614', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (166, N'615', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (581, N'73', CAST(0x0000A5E700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (169, N'802', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (208, N'72', CAST(0x0000A5C900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (171, N'804', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (172, N'805', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (189, N'802', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (209, N'73', CAST(0x0000A5C900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (191, N'804', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (582, N'74', CAST(0x0000A5E700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (192, N'805', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (193, N'806', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (194, N'807', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (195, N'808', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (196, N'809', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (197, N'810', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (561, N'700', CAST(0x0000A5E600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (199, N'902', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (200, N'901', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (201, N'903', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (202, N'904', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (203, N'905', CAST(0x0000A5C600000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (210, N'74', CAST(0x0000A5C900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (212, N'76', CAST(0x0000A5C900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (387, N'306', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (388, N'307', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (442, N'64', CAST(0x0000A5DE00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (281, N'172', CAST(0x0000A5CC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (306, N'191', CAST(0x0000A5CE00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (307, N'192', CAST(0x0000A5CE00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (308, N'194', CAST(0x0000A5CE00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (324, N'400', CAST(0x0000A5D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (242, N'459', CAST(0x0000A5CA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (243, N'460', CAST(0x0000A5CA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (443, N'65', CAST(0x0000A5DE00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (523, N'302', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (429, N'0', CAST(0x0000A5DB00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (446, N'68', CAST(0x0000A5DE00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (253, N'709', CAST(0x0000A5CA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (254, N'710', CAST(0x0000A5CA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (524, N'303', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (320, N'234', CAST(0x0000A5D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (1279, N'88', CAST(0x0000A7B400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (289, N'179', CAST(0x0000A5CC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (584, N'76', CAST(0x0000A5E700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (525, N'304', CAST(0x0000A5E200000000 AS DateTime), N'0')
GO
print 'Processed 100 total records'
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (526, N'305', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (527, N'306', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (472, N'232', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (528, N'307', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (474, N'234', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (475, N'235', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (476, N'236', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (477, N'237', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (478, N'238', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (479, N'239', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (480, N'240', CAST(0x0000A5DF00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (514, N'705', CAST(0x0000A5E100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (515, N'706', CAST(0x0000A5E100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (516, N'707', CAST(0x0000A5E100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (517, N'708', CAST(0x0000A5E100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (518, N'709', CAST(0x0000A5E100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (519, N'710', CAST(0x0000A5E100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (529, N'308', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (530, N'309', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (531, N'310', CAST(0x0000A5E200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (537, N'183', CAST(0x0000A5E500000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (538, N'184', CAST(0x0000A5E500000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (539, N'185', CAST(0x0000A5E500000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (540, N'186', CAST(0x0000A5E500000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (541, N'187', CAST(0x0000A5E500000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (542, N'188', CAST(0x0000A5E500000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (588, N'80', CAST(0x0000A5E700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (593, N'143', CAST(0x0000A5E800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (1876, N'36', CAST(0x0000A92900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (1879, N'39', CAST(0x0000A92900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (535, N'181', CAST(0x0000A5E500000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (24, N'511', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (25, N'512', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (26, N'513', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (27, N'514', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (28, N'515', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (31, N'802', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (33, N'804', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (34, N'805', CAST(0x0000A5BC00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (326, N'236', CAST(0x0000A5D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (327, N'237', CAST(0x0000A5D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (328, N'238', CAST(0x0000A5D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (329, N'239', CAST(0x0000A5D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (176, N'301', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (177, N'302', CAST(0x0000A5C400000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (51, N'302', CAST(0x0000A5BD00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (312, N'223', CAST(0x0000A5D100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (313, N'224', CAST(0x0000A5D100000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (342, N'88', CAST(0x0000A5D700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (349, N'283', CAST(0x0000A5D700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (360, N'301', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (348, N'283', CAST(0x0000A5D700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (350, N'284', CAST(0x0000A5D700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (351, N'285', CAST(0x0000A5D700000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (361, N'302', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (362, N'303', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (363, N'304', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (364, N'305', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (365, N'306', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (366, N'307', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (367, N'308', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (368, N'308', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (369, N'309', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2574, N'78', CAST(0x0000AA7800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (267, N'501', CAST(0x0000A5CB00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (272, N'505', CAST(0x0000A5CB00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (273, N'506', CAST(0x0000A5CB00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (277, N'509', CAST(0x0000A5CB00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (278, N'510', CAST(0x0000A5CB00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (352, N'291', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (354, N'292', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (355, N'293', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (356, N'294', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (357, N'295', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (358, N'296', CAST(0x0000A5D800000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (398, N'709', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (399, N'710', CAST(0x0000A5D900000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (404, N'311', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (405, N'312', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (406, N'313', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (407, N'314', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (408, N'315', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (409, N'316', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (410, N'316', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (411, N'317', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (412, N'318', CAST(0x0000A5DA00000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2180, N'178', CAST(0x0000A9D200000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (492, N'57', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (494, N'59', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (495, N'60', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (497, N'301', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (498, N'302', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (499, N'303', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (500, N'304', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (501, N'305', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (502, N'306', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (503, N'307', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (504, N'308', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (505, N'309', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (506, N'310', CAST(0x0000A5E000000000 AS DateTime), N'0')
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (536, N'182', CAST(0x0000A5E500000000 AS DateTime), N'0')
GO
print 'Processed 200 total records'
INSERT [dbo].[Venta_Especial] ([Numero], [Clave], [Fecha], [Cumplido]) VALUES (2633, N'34', CAST(0x0000AA8F00000000 AS DateTime), N'0')
SET IDENTITY_INSERT [dbo].[Venta_Especial] OFF
/****** Object:  Table [dbo].[VALE_CAJA_DETALLE]    Script Date: 01/02/2020 13:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VALE_CAJA_DETALLE](
	[ID_VALE] [int] NULL,
	[ID_PRODUCTO] [varchar](25) NULL,
	[CANTIDAD] [float] NULL,
	[PRECIO_VENTA] [float] NULL,
	[FECHA] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VALE_CAJA]    Script Date: 01/02/2020 13:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VALE_CAJA](
	[ID_VALE] [int] IDENTITY(1,1) NOT NULL,
	[ID_VENTA] [int] NULL,
	[IMPORTE] [float] NULL,
	[FECHA] [datetime] NULL,
	[APLICADO] [varchar](1) NULL,
	[ID_USUARIO] [int] NULL,
	[CANTIDAD] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
