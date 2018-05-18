using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using Nez.UI;

namespace NezTestProject {
    public static class UIManager {
        
        public static void SetupUI(Scene scene) {
            scene.addRenderer(new ScreenSpaceRenderer(100, (int)RenderLayer.ScreenSpace));
            scene.addRenderer(new RenderLayerExcludeRenderer(0, (int)RenderLayer.ScreenSpace));

            var canvas = scene.createEntity("ui").addComponent(new UICanvas());
            canvas.isFullScreen = true;
            canvas.renderLayer = (int)RenderLayer.ScreenSpace;
            
            var table = canvas.stage.addElement(new Table());
            table.setFillParent(true).top().left().padTop(10);

            var bar = new ProgressBar(0, 1, 0.1f, false, ProgressBarStyle.create(Color.Yellow, Color.Black));
            table.add(bar);
            table.row().setPadTop(10);

            var slider = new Slider(0, 1, 0.1f, false, SliderStyle.create(Color.White, Color.Black));
            table.add(slider);
            table.row();
        }
    }
}
