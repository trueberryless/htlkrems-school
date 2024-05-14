<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <positions>
            <xsl:apply-templates select="//position/@type[not(.=preceding::position/@type)]/.."/>
        </positions>
    </xsl:template>

    <xsl:template match="position">
        <position>
            <xsl:attribute name="id">
                <xsl:value-of select="@type"/>
            </xsl:attribute>
            <xsl:apply-templates select="//teams/team">
                <xsl:with-param name="type">
                    <xsl:value-of select="@type"/>
                </xsl:with-param>
            </xsl:apply-templates>
        </position>
    </xsl:template>

    <xsl:template match="team">
        <xsl:param name="type"/>
        <team>
            <xsl:attribute name="code">
                <xsl:value-of select="nation/FIFA-code"/>
            </xsl:attribute>
            <xsl:apply-templates select="position[@type=$type]/player"/>
        </team>
    </xsl:template>

    <xsl:template match="player">
        <player>
            <xsl:value-of select="concat(name/first-name, ' ', name/last-name)"/>
        </player>
    </xsl:template>
</xsl:stylesheet>