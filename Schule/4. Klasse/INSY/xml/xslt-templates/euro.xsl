<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <teams> <!-- short form of: <xsl:element name="teams"/> -->
            <xsl:apply-templates select="//teams/team"/>
        </teams>
    </xsl:template>

    <xsl:template match="team">
        <team>
            <xsl:attribute name="id">
                <xsl:value-of select="nation/FIFA-code"/>
            </xsl:attribute>
            <xsl:apply-templates select="position/player"/>
        </team>
    </xsl:template>

    <xsl:template match="player">
        <player>
            <xsl:value-of select="concat(name/first-name, ' ', name/last-name)"/>
        </player>
    </xsl:template>
</xsl:stylesheet>