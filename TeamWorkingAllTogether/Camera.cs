using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamWorkingAllTogether
{
    class Camera
    {
            protected float _zoom; // Camera Zoom
            public Matrix _transform; // Matrix Transform
            public Vector2 _pos; // Camera Position
            protected float _rotation; // Camera Rotation

            public Camera()
            {
                _zoom = 1.0f;
                _rotation = 0.0f;
                _pos = Vector2.Zero;
            }

            // Sets and gets zoom
            public float Zoom
            {
                get { return _zoom; }
                set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
            }

            public float Rotation
            {
                get { return _rotation; }
                set { _rotation = value; }
            }

            // Auxiliary function to move the camera
            public void Move(Vector2 amount)
            {
                _pos += amount;
            }

            // Get set position
            public Vector2 Pos
            {
                get { return _pos; }
                set { _pos = value; }
            }

            public Matrix get_transformation(GraphicsDevice graphicsDevice, int viewportWidth,int viewportHeight)
            {
                _transform =       // Thanks to o KB o for this solution
                  Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                             Matrix.CreateRotationZ(Rotation) *
                                             Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                             Matrix.CreateTranslation(new Vector3(viewportWidth * 0.5f, viewportHeight * 0.5f, 0));
                return _transform;
            }

            // GOES IN DRAW

                //        Camera2d cam = new Camera2d();
                //        cam.Pos = new Vector2(500.0f,200.0f);
                //        // cam.Zoom = 2.0f // Example of Zoom in
                //        // cam.Zoom = 0.5f // Example of Zoom out

                //        //// if using XNA 3.1
                //        spriteBatch.Begin(SpriteBlendMode.AlphaBlend,
                //                        SpriteSortMode.Immediate,
                //                        SaveStateMode.SaveState,
                //                        cam.get_transformation(device /*Send the variable that has your graphic device here*/));
 
                ////// if using XNA 4.0
                //spriteBatch.Begin(SpriteSortMode.BackToFront,
                //                        BlendState.AlphaBlend,
                //                        null,
                //                        null,
                //                        null,
                //                        null,
                //                        cam.get_transformation(device /*Send the variable that has your graphic device here*/));
 
                //// Draw Everything
                //// You can draw everything in their positions since the cam matrix has already done the maths for you 
 
                //spriteBatch.End(); // Call Sprite Batch End
    }
}
