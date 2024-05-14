<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <lineage>
            <xsl:apply-templates select="//person[not(descendant::person)]">
                <xsl:with-param name="generation">
                    <xsl:value-of select="0"/>
                </xsl:with-param>
            </xsl:apply-templates>
        </lineage>
    </xsl:template>

    <xsl:template match="person">
        <xsl:param name="generation"/>
        <person>
            <xsl:if test="not($generation = 0)">
                <xsl:attribute name="generation">
                    <xsl:value-of select="$generation"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:copy-of select="name"/>
            <xsl:apply-templates select="parent::parents/parent::person">
                <xsl:with-param name="generation">
                    <xsl:value-of select="$generation + 1"/>
                </xsl:with-param>
            </xsl:apply-templates>
        </person>
    </xsl:template>
</xsl:stylesheet>