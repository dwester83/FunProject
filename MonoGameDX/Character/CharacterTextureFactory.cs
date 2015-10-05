using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_DX.Character
{
    public class CharacterTextureFactory
    {
        private static CharacterTextureFactory instance;

        public Texture2D PlayerTexture { get; set; }
        public Texture2D HelmetTexture { get; set; }
        public Texture2D GlovesTexture { get; set; }
        public Texture2D ChestTexture { get; set; }
        public Texture2D BootsTexture { get; set; }
        public Texture2D PantsTexture { get; set; }
        public Texture2D CloakTexture { get; set; }

        
        public Color PlayerSkinColor { get; set; }
        public Color PlayerEyeColor { get; set; }
        public Color PlayerHairColor { get; set; }
        public Color HelmetPrimaryColor { get; set; }
        public Color HelmetSecondaryColor { get; set; }
        public Color GlovesPrimaryColor { get; set; }
        public Color GlovesSecondaryColor { get; set; }
        public Color ChestPrimaryColor { get; set; }
        public Color ChestSecondaryColor { get; set; }
        public Color BootsPrimaryColor { get; set; }
        public Color BootsSecondaryColor { get; set; }
        public Color PantsPrimaryColor { get; set; }
        public Color PantsSecondaryColor { get; set; }
        public Color CloakPrimaryColor { get; set; }
        public Color CloakSecondaryColor { get; set; }
        private Color StartingPlayerSkinColor { get; }
        private Color StartingPlayerEyeColor { get; }
        private Color StartingPlayerHairColor = new Color(255, 243, 146, 255);
        private Color StartingHelmetPrimaryColor { get; }
        private Color StartingHelmetSecondaryColor { get; }
        private Color StartingGlovesPrimaryColor = new Color(162, 186, 255, 255);
        private Color StartingGlovesSecondaryColor = new Color(81, 130, 255, 255);
        private Color StartingChestPrimaryColor { get; }
        private Color StartingChestSecondaryColor { get; }
        private Color StartingBootsPrimaryColor { get; }
        private Color StartingBootsSecondaryColor { get; }
        private Color StartingPantsPrimaryColor { get; }
        private Color StartingPantsSecondaryColor { get; }
        private Color StartingCloakPrimaryColor { get; }
        private Color StartingCloakSecondaryColor { get; }
        private Color TransparentColor = new Color(0, 0, 0, 0);
        public RenderTarget2D Target { get; internal set; }

        private CharacterTextureFactory() {}
        public static CharacterTextureFactory GetInstance()
        {
            if(instance == null)
            {
                instance = new CharacterTextureFactory();
            }

            return instance;
        }

        public Texture2D GetCharacterTexture()
        {
            UpdateTexture();
            return PlayerTexture;
        }

        private void UpdateTexture()
        {
            ReplaceColors(PlayerTexture);
            ReplaceColors(GlovesTexture);
        }

        private void ReplaceColors(Texture2D texture)
        {
            Color[] playersArray = new Color[PlayerTexture.Width * PlayerTexture.Height];
            PlayerTexture.GetData<Color>(playersArray);
            Color[] tempArray = new Color[texture.Width * texture.Height];
            texture.GetData<Color>(tempArray);
            for (int x = 0; x < playersArray.Length; x++)
            {

                if (!tempArray[x].Equals(TransparentColor))
                {
                    playersArray[x] = tempArray[x];
                }
                //Console.WriteLine(colors2D[x, y].ToString());
                if (playersArray[x].Equals(StartingPlayerHairColor))
                {
                    playersArray[x] = PlayerHairColor;
                }
                else if (playersArray[x].Equals(StartingGlovesPrimaryColor))
                {
                    playersArray[x] = GlovesPrimaryColor;
                }
                else if (playersArray[x].Equals(StartingGlovesSecondaryColor))
                {
                    playersArray[x] = GlovesSecondaryColor;
                }

            }
            PlayerTexture.SetData<Color>(playersArray);
        }
    }
}