<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html" indent="yes"/>

    <!-- Template principal -->
    <xsl:template match="/">
        <html>
            <head>
                <title>Meilleurs Scores par Niveau</title>
            </head>
            <body>
                <h1>Meilleurs Scores par Niveau</h1>
                <table border="1" cellpadding="5" cellspacing="0">
                    <tr>
                        <th>Niveau</th>
                        <th>Score</th>
                        <th>Date</th>
                    </tr>

                    <!-- Meilleur Score pour Easy -->
                    <xsl:for-each select="GameSaves/Game[Level='Easy']">
                        <xsl:sort select="Score" data-type="number" order="descending"/>
                        <xsl:if test="position() = 1">
                            <tr>
                                <td>Easy</td>
                                <td><xsl:value-of select="Score"/></td>
                                <td><xsl:value-of select="Date"/></td>
                            </tr>
                        </xsl:if>
                    </xsl:for-each>

                    <!-- Meilleur Score pour Medium -->
                    <xsl:for-each select="GameSaves/Game[Level='Medium']">
                        <xsl:sort select="Score" data-type="number" order="descending"/>
                        <xsl:if test="position() = 1">
                            <tr>
                                <td>Medium</td>
                                <td><xsl:value-of select="Score"/></td>
                                <td><xsl:value-of select="Date"/></td>
                            </tr>
                        </xsl:if>
                    </xsl:for-each>

                    <!-- Meilleur Score pour Hard -->
                    <xsl:for-each select="GameSaves/Game[Level='Hard']">
                        <xsl:sort select="Score" data-type="number" order="descending"/>
                        <xsl:if test="position() = 1">
                            <tr>
                                <td>Hard</td>
                                <td><xsl:value-of select="Score"/></td>
                                <td><xsl:value-of select="Date"/></td>
                            </tr>
                        </xsl:if>
                    </xsl:for-each>

                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
