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
        public Texture2D PantsTexture { get; set; }
        public Texture2D BootsTexture { get; set; }
        public Texture2D CloakTexture { get; set; }
                 
        //NEED TO SWITCH THESE AROUND WITH STARTING COLORS
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

        private Color StartingPlayerSkinColor = new Color(255, 204, 128, 255);
        private Color StartingPlayerEyeColor = new Color(128, 203, 196, 255);
        private Color StartingPlayerHairColor = new Color(93, 64, 55, 255);
        private Color StartingHelmetPrimaryColor = new Color(84, 110, 122, 255);
        private Color StartingHelmetSecondaryColor = new Color(244, 81, 30, 255);
        private Color StartingGlovesPrimaryColor = new Color(96, 125, 139, 255);
        private Color StartingGlovesSecondaryColor = new Color(255, 87, 34, 255);
        private Color StartingChestPrimaryColor = new Color(144, 164, 174, 255);
        private Color StartingChestSecondaryColor = new Color(255, 138, 101, 255);
        private Color StartingBootsPrimaryColor = new Color(69, 90, 100, 255);
        private Color StartingBootsSecondaryColor = new Color(230, 74, 25, 255);
        private Color StartingPantsPrimaryColor = new Color(120, 144, 156, 255);
        private Color StartingPantsSecondaryColor = new Color(255, 112, 67, 255);
        private Color StartingCloakPrimaryColor = new Color(55, 71, 79, 255);
        private Color StartingCloakSecondaryColor = new Color(216, 67, 21, 255);
        private Color TransparentColor = new Color(0, 0, 0, 0);

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
            Color[] playersArray = new Color[PlayerTexture.Width * PlayerTexture.Height];
            PlayerTexture.GetData<Color>(playersArray);
            Color[] chestArray = new Color[ChestTexture.Width * ChestTexture.Height];
            ChestTexture.GetData<Color>(chestArray);
            Color[] pantsArray = new Color[PantsTexture.Width * PantsTexture.Height];
            PantsTexture.GetData<Color>(pantsArray);
            Color[] glovesArray = new Color[GlovesTexture.Width * GlovesTexture.Height];
            GlovesTexture.GetData<Color>(glovesArray);
            Color[] helmetArray = new Color[HelmetTexture.Width * HelmetTexture.Height];
            HelmetTexture.GetData<Color>(helmetArray);
            Color[] bootsArray = new Color[BootsTexture.Width * BootsTexture.Height];
            BootsTexture.GetData<Color>(bootsArray);
            Color[] cloakArray = new Color[CloakTexture.Width * CloakTexture.Height];
            CloakTexture.GetData<Color>(cloakArray);

            for (int x = 0; x < playersArray.Length; x++)
            {
                if (!chestArray[x].Equals(TransparentColor))
                {
                    playersArray[x] = chestArray[x];
                }
                if (!pantsArray[x].Equals(TransparentColor))
                {
                    playersArray[x] = pantsArray[x];
                }
                if (!glovesArray[x].Equals(TransparentColor))
                {
                    playersArray[x] = glovesArray[x];
                }
                if (!bootsArray[x].Equals(TransparentColor))
                {
                    playersArray[x] = bootsArray[x];
                }
                if (!helmetArray[x].Equals(TransparentColor))
                {
                    playersArray[x] = helmetArray[x];
                }
                if (!cloakArray[x].Equals(TransparentColor))
                {
                    playersArray[x] = cloakArray[x];
                }

                if (playersArray[x].Equals(StartingPlayerHairColor))
                {
                    playersArray[x] = PlayerHairColor;
                }



            }
            PlayerTexture.SetData<Color>(playersArray);
        }
    }
}