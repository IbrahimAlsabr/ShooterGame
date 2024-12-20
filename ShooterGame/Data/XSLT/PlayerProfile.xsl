<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

    <!-- Ensure output is formatted as HTML -->
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
        <html>
            <body>
                <h1>Player Profile</h1>
                <p>Player Name:
                    <xsl:value-of select="PlayerProfile/PlayerName"/>
                </p>
                <p>Last Level:
                    <xsl:value-of select="PlayerProfile/LastLevel"/>
                </p>
                <p>Last Score:
                    <xsl:value-of select="PlayerProfile/LastScore"/>
                </p>
                <p>Last Played:
                    <xsl:value-of select="PlayerProfile/LastPlayed"/>
                </p>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>