<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <catalog>
            <xsl:apply-templates select="child::*"/>
        </catalog>
    </xsl:template>

    <xsl:template match="*[child::*]">
        <node>
            <xsl:attribute name="name">
                <xsl:value-of select="name()"/>
            </xsl:attribute>
            <xsl:apply-templates select="child::*[child::*]"/>
            <xsl:apply-templates select="child::*[not(child::*)]"/>
        </node>
    </xsl:template>

    <xsl:template match="*[not(child::*)]">
        <leaf>
            <xsl:attribute name="name">
                <xsl:value-of select="name()"/>
            </xsl:attribute>
            <xsl:attribute name="par">
                <xsl:value-of select="count(ancestor::*)"/>
            </xsl:attribute>
            <xsl:apply-templates select="child::*[child::*]"/>
        </leaf>
    </xsl:template>
</xsl:stylesheet>