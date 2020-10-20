using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Chroma;
using Chroma.Graphics;
using Chroma.ContentManagement.FileSystem;
using System.IO;

namespace MachinaBreaker
{
    class GameCore : Game
    {
        public Texture playerSheet;

        public GameCore()
        {
            Content = new FileSystemContentProvider(this, Path.Combine(LocationOnDisk, "Assets/"));
        }

        protected override void LoadContent()
        {
            playerSheet = Content.Load<Texture>("ProtoProtagComplete-Sheet.png");
        }
        protected override void Update(float delta)
        {
            base.Update(delta);
        }

        protected override void Draw(RenderContext context)
        {
            context.DrawTexture(playerSheet, new Vector2(0,0), Vector2.One, Vector2.Zero, 0f);
        }

    }
}
