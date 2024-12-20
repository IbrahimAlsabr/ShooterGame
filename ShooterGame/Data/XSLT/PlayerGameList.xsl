<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
        <html>
            <body>
                <table border="1" cellpadding="5" cellspacing="0">
                    <tr>
                        <th>Joueur</th>
                        <th>Score</th>
                        <th>Date</th>
                        <th>Level</th>
                    </tr>
                    <xsl:for-each select="GameSaves/Game">
                        <tr>
                            <td>
                                <xsl:value-of select="PlayerName"/>
                            </td>
                            <td>
                                <xsl:value-of select="Score"/>
                            </td>
                            <td>
                                <xsl:value-of select="Date"/>
                            </td>
                            <td>
                                <xsl:value-of select="Level"/>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>


