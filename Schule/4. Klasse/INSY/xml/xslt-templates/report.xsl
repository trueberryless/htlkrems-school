<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <report>
            <title>
                <xsl:value-of select="//title"/>
            </title>
            <authors>
                <xsl:for-each select="//description/authors/node()">
                    <xsl:variable name="current-node">
                        <xsl:value-of select="."/>
                    </xsl:variable>
                    <xsl:variable name="current-id">
                        <xsl:value-of select="@id"/>
                    </xsl:variable>
                    <xsl:value-of select="$current-node"/>
                    <xsl:apply-templates select="//authors/*[@id = $current-id]"/>
                </xsl:for-each>
            </authors>
            <content>
                <xsl:value-of select="//content"/>
            </content>
        </report>
    </xsl:template>

    <xsl:template match="author | sampler">
        <xsl:if test="name">
            <xsl:value-of select="name"/>
        </xsl:if>
        <xsl:if test="first-name">
            <xsl:value-of select="first-name"/>
            <xsl:text> </xsl:text>
        </xsl:if>
        <xsl:if test="middle-name">
            <xsl:value-of select="middle-name"/>
            <xsl:text> </xsl:text>
        </xsl:if>
        <xsl:if test="last-name">
            <xsl:value-of select="last-name"/>
        </xsl:if>
    </xsl:template>
</xsl:stylesheet>