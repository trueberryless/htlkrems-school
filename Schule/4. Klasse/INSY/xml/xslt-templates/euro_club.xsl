<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <clubs>
            <xsl:apply-templates select="//club[not(.=preceding::club)]"/>
        </clubs>
    </xsl:template>

    <xsl:template match="club">
        <xsl:variable name="current-club">
            <xsl:value-of select="."/>
        </xsl:variable>
        <club>
            <xsl:attribute name="id">
                <xsl:value-of select="$current-club"/>
            </xsl:attribute>
            <xsl:attribute name="playercount">
                <xsl:value-of select="count(//player[club=$current-club])"/>
            </xsl:attribute>
            <xsl:apply-templates select="//player[club=$current-club]"/>
        </club>
    </xsl:template>

    <xsl:template match="player">
        <player>
            <xsl:attribute name="code">
                <xsl:value-of select="ancestor::team/nation/FIFA-code"/>
            </xsl:attribute>
            <xsl:value-of select="concat(substring(name/first-name, 1, 1), '. ', name/last-name)"/>
        </player>
    </xsl:template>
</xsl:stylesheet>