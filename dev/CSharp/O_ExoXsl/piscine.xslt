<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:template match="div[@class='seu-wi seu-wi-schedules']">
		<periodes>
		<xsl:apply-templates select="button[class='tab-toggle']"/>
			</periodes>
	</xsl:template>
	<xsl:template match="button[class='tab-toggle']">
		<periode>
			<xsl:value-of select="."/>
		</periode>
	</xsl:template>
</xsl:stylesheet>
