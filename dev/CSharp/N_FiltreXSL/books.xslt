<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:template match="catalog">
		<html>
			<head>
				<title>Liste des livres</title>
			</head>
			<body>
				<h2>Liste des livres</h2>
				<table style="border-style:solid;border-width:1px;border-color:maroon">
					<tr style="font-weight:bold;background-color:silver">
						<td>Id</td>
						<td>Auteur</td>
						<td>Titre</td>
						<td>Prix</td>
					</tr>
					<xsl:apply-templates select="book"/>
				</table>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="book">
		<tr style="background-color:white">
			<td>
				<xsl:value-of select="@id"/>
			</td>
			<td>
				<xsl:value-of select="author"/>
			</td>
			<td>
				<xsl:value-of select="title"/>
			</td>
			<td>
				<xsl:value-of select="price"/>
			</td>
		</tr>

	</xsl:template>
</xsl:stylesheet>
