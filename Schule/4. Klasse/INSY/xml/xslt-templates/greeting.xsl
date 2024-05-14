<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <xsl:element name="hugo">
            <xsl:attribute name="name">
                <xsl:value-of select="greeting/@origin"/>
            </xsl:attribute>
            <xsl:value-of select="greeting/topic/event"/>
        </xsl:element>
    </xsl:template>
</xsl:stylesheet>