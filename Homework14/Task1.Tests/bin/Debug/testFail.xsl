<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="xml" indent="yes"/>
<xsl:template match="/">
<Plants>
<Fruits>
<xsl:apply-templates/>
</Fruits>
</Plants>
</xsl:template>

<xsl:template match="Apple">
<Apple>
<color>
<xsl:value-of select="@color" />
</color>
</Apple>
</xsl:template>

<xsl:template match="Lemon">
<Lemon><color>
<xsl:value-of select="@color" />
</color>
</Lemon>
</xsl:template>
</xsl:stylesheet>