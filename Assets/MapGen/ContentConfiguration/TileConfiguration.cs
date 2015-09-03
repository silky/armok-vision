﻿using RemoteFortressReader;
using System.Collections.Generic;
using System.Xml.Linq;

public class TileConfiguration<T> : ContentConfiguration<T> where T : IContent, new()
{
    TiletypeMatcher<Content> tiletypeMatcher = new TiletypeMatcher<Content>();
    Content defaultTile = new Content();

    protected override void ParseElementConditions(XElement elemtype, Content content)
    {
        var elemTiletypes = elemtype.Elements("tiletype");
        foreach (XElement elemTiletype in elemTiletypes)
        {
            XAttribute elemToken = elemTiletype.Attribute("token");
            if (elemToken != null)
            {
                if (elemToken.Value == "NONE")
                    defaultTile = content;
                else
                    tiletypeMatcher[elemToken.Value] = content;
                continue;
            }
        }
    }

    public override bool GetValue(MapDataStore.Tile tile, MeshLayer layer, out T value)
    {
        Content cont;
        if(tiletypeMatcher.Get(tile.tileType, out cont))
        {
            value = cont.GetValue(tile, layer);
            return true;
        }
        value = defaultTile.GetValue(tile, layer);
        return false;
    }
}