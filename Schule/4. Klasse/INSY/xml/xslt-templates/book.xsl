<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
        <h1>Library Books</h1>
        <table>
            <tr>
                <th>ID</th>
                <th>Title</th>
                <th>Author</th>
                <th>Year</th>
                <th>Publisher</th>
                <th>Price</th>
                <th>Borrower</th>
            </tr>
            <xsl:apply-templates select="//books/book">
                <xsl:sort select="year" data-type="number" order="ascending"/>
            </xsl:apply-templates>
        </table>
    </xsl:template>

    <xsl:template match="book">
        <xsl:variable name="book-id">
            <xsl:value-of select="@id"/>
        </xsl:variable>
        <tr>
            <td>
                <xsl:value-of select="@id"/>
            </td>
            <td>
                <xsl:value-of select="title"/>
            </td>
            <td>
                <xsl:value-of select="author"/>
            </td>
            <td align='right'>
                <xsl:if test="1900 > year">
                    <strong>
                        <xsl:value-of select="year"/>
                    </strong>
                </xsl:if>
                <xsl:if test="year >= 1900">
                    <xsl:value-of select="year"/>
                </xsl:if>
            </td>
            <td>
                <xsl:value-of select="publisher"/>
            </td>
            <xsl:if test="price/@currency='USD' and 8 >= price or price/@currency='GBP' and 7 >= price or price/@currency='EUR'">
                <td align='right'>
                    <xsl:choose>
                        <xsl:when test="price/@currency='USD'">
                            <xsl:text>$ </xsl:text>
                        </xsl:when>
                        <xsl:when test="price/@currency='GBP'">
                            <xsl:text>£ </xsl:text>
                        </xsl:when>
                        <xsl:when test="price/@currency='EUR'">
                            <xsl:text>€ </xsl:text>
                        </xsl:when>
                    </xsl:choose>
                    <xsl:value-of select="price"/>
                </td>
            </xsl:if>
            <xsl:if test="price/@currency='USD' and price > 8 and 10 >= price or price/@currency='GBP' and price > 7 and 9 >= price">
                <td align='right' style="background-color:#FFFF00;">
                    <xsl:choose>
                        <xsl:when test="price/@currency='USD'">
                            <xsl:text>$ </xsl:text>
                        </xsl:when>
                        <xsl:when test="price/@currency='GBP'">
                            <xsl:text>£ </xsl:text>
                        </xsl:when>
                        <xsl:when test="price/@currency='EUR'">
                            <xsl:text>€ </xsl:text>
                        </xsl:when>
                    </xsl:choose>
                    <xsl:value-of select="price"/>
                </td>
            </xsl:if>
            <xsl:if test="price/@currency='USD' and price > 10 or price/@currency='GBP' and price > 9">
                <td align='right' style="color:#FF0000;">
                    <xsl:choose>
                        <xsl:when test="price/@currency='USD'">
                            <xsl:text>$ </xsl:text>
                        </xsl:when>
                        <xsl:when test="price/@currency='GBP'">
                            <xsl:text>£ </xsl:text>
                        </xsl:when>
                        <xsl:when test="price/@currency='EUR'">
                            <xsl:text>€ </xsl:text>
                        </xsl:when>
                    </xsl:choose>
                    <xsl:value-of select="price"/>
                </td>
            </xsl:if>
            <td>
                <xsl:for-each select="//lent-out[book=$book-id]">
                    <xsl:value-of select="borrower"/>
                    <xsl:text> (</xsl:text>
                    <xsl:value-of select="return-date"/>
                    <xsl:text>)</xsl:text>
                    <xsl:if test="./following-sibling::*">
                        <xsl:text>, </xsl:text>
                    </xsl:if>
                </xsl:for-each>
            </td>
        </tr>
    </xsl:template>
</xsl:stylesheet>