<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <term>
            <xsl:apply-templates select="child::*"/>
        </term>
    </xsl:template>

    <xsl:template match="or | and">
        <xsl:variable name="tag">
            <xsl:value-of select="name()"/>
        </xsl:variable>
        <xsl:text>(</xsl:text>
        <xsl:for-each select="child::*">
            <xsl:apply-templates select="."/>
            <xsl:if test="following-sibling::*">
                <xsl:value-of select="concat(' ', $tag, ' ')"/>
            </xsl:if>
        </xsl:for-each>
        <xsl:text>)</xsl:text>
    </xsl:template>

    <xsl:template match="not">
        <xsl:text>!(</xsl:text>
        <xsl:apply-templates select="child::*"/>
        <xsl:text>)</xsl:text>
    </xsl:template>

    <xsl:template match="term">
        <xsl:value-of select="text()"/>
    </xsl:template>

</xsl:stylesheet>