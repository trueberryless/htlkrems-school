<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <stats>
            <xsl:for-each select="//groups/group/team">
                <xsl:variable name="current-team">
                    <xsl:value-of select="."/>
                </xsl:variable>
                <team>
                    <xsl:attribute name="group">
                        <xsl:value-of select="parent::*/@id"/>
                    </xsl:attribute>
                    <xsl:attribute name="code">
                        <xsl:value-of select="."/>
                    </xsl:attribute>
                    <xsl:copy-of select="//teams/team/nation[FIFA-code=$current-team]/name"/>
                    <opponents>
                        <xsl:for-each select="//group[team=$current-team]/team[not(.=$current-team)] | //match[team=$current-team]/team[not(.=$current-team)]">
                            <xsl:copy-of select="."/>
                        </xsl:for-each>
                    </opponents>
                </team>
            </xsl:for-each>
        </stats>
    </xsl:template>
</xsl:stylesheet>