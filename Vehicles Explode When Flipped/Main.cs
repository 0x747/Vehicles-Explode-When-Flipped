using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.UI;

namespace Vehicles_Explode_When_Flipped {
    public class Main : Script {

        public Main() {
            Tick += OnTick;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }

        public void OnTick(object sender, EventArgs eventArgs) {

            //Game.Player.WantedLevel = 0;
            //Game.Player.Character.IsInvincible = true;

            //TextElement Status = new TextElement(
            //    $"Engine: {Game.Player.Character.LastVehicle.EngineHealth} ~n~" +
            //    $"{Game.Player.Character.LastVehicle.IsEngineRunning} ~n~" +
            //    $"Tank: {Game.Player.Character.LastVehicle.PetrolTankHealth}",
            //    new PointF(50f, 360f),     // Text position on a 1280x720 pixel space.
            //    0.4f,                      // Text scaling factor. 
            //    Color.GhostWhite,          // Text color
            //    GTA.UI.Font.ChaletLondon,  // Font 
            //    Alignment.Left,            // Text alignment
            //    true,                      // Text shadow
            //    true                       // Text outline
            //);
            //Status.Draw();

            foreach (Vehicle vehicle in World.GetAllVehicles()) {
                if (vehicle.EngineHealth > -1f && !vehicle.IsInAir && vehicle.Type != VehicleType.Bicycle && (vehicle.Rotation.Y > 90f || vehicle.Rotation.Y < -90f)) {
                    vehicle.EngineHealth -= 1;
                }
                else if (vehicle.EngineHealth < -3650) {
                    vehicle.Explode();
                }
            }
            
        }
        public void OnKeyDown(object sender, KeyEventArgs e) { }
        public void OnKeyUp(object sender, KeyEventArgs e) { }
    }
}
