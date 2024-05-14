<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <teams>
            <xsl:apply-templates select="//group/team"/>
        </teams>
    </xsl:template>

    <xsl:template match="group/team">
        <xsl:variable name="FIFA-code">
            <xsl:value-of select="text()"/>
        </xsl:variable>
        <xsl:variable name="opponents" select="//group[team/text()=$FIFA-code]/team[not(text()=$FIFA-code)] |
                    //match[team/text()=$FIFA-code]/team[not(text()=$FIFA-code) and not(text()=//group[team/text()=$FIFA-code]/team/text())]"/>
        <team>
            <xsl:attribute name="group">
                <xsl:value-of select="parent::group/@id"/>
            </xsl:attribute>
            <xsl:attribute name="code">
                <xsl:value-of select="$FIFA-code"/>
            </xsl:attribute>
            <name>
                <xsl:value-of select="//teams/team/nation[FIFA-code=$FIFA-code]/name"/>
            </name>
            <opponents>
                <xsl:attribute name="count">
                    <xsl:value-of select="count($opponents)"/>
                </xsl:attribute>
                <xsl:for-each select="$opponents">
                    <team>
                        <xsl:attribute name="code">
                            <xsl:value-of select="text()"/>
                        </xsl:attribute>
                    </team>
                </xsl:for-each>
            </opponents>
        </team>
    </xsl:template>
</xsl:stylesheet>