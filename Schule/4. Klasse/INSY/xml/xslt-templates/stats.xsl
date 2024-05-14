<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <stats>
            <xsl:apply-templates select="//group/team" mode="standard"/>
        </stats>
    </xsl:template>

    <xsl:template match="group/team" mode="standard">
        <xsl:param name="short-name">
            <xsl:value-of select="text()"/>
        </xsl:param>
        <team>
            <xsl:attribute name="group">
                <xsl:value-of select="ancestor::group/@id"/>
            </xsl:attribute>
            <xsl:attribute name="code">
                <xsl:value-of select="$short-name"/>
            </xsl:attribute>
            <name>
                <xsl:value-of select="//nation[short-name=$short-name]/name/text()"/>
            </name>
            <opponents>
                <xsl:apply-templates select="following-sibling::*|preceding-sibling::*|//match[team/text()=$short-name]/team[not(text()=$short-name)]" mode="sibling"/>
            </opponents>
        </team>
    </xsl:template>

    <xsl:template match="team" mode="sibling">
        <team>
            <xsl:attribute name="code">
                <xsl:value-of select="text()"/>
            </xsl:attribute>
        </team>
    </xsl:template>
</xsl:stylesheet>