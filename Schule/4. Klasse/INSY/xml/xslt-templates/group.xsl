<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <groups>
            <xsl:apply-templates select="//group"/>
        </groups>
    </xsl:template>

    <xsl:template match="//group">
        <group>
            <xsl:attribute name="id">
                <xsl:value-of select="@id"/>
            </xsl:attribute>
            <xsl:apply-templates select="team"/>
        </group>
    </xsl:template>

    <xsl:template match="//group/team">
        <xsl:param name="short-name">
            <xsl:value-of select="text()"/>
        </xsl:param>
        <team>
            <xsl:attribute name="code">
                <xsl:value-of select="$short-name"/>
            </xsl:attribute>
            <xsl:attribute name="round">
                <xsl:value-of select="count(//match/team[text()=$short-name]) + 1"/>
            </xsl:attribute>
        </team>
    </xsl:template>
</xsl:stylesheet>