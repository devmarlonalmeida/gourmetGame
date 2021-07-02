using System;
using System.Windows.Forms;
using vbInteraction = Microsoft.VisualBasic.Interaction;
using JogoGourmet.Model.Models;

namespace JogoGourmet.View
{
    public partial class Main : Form
    {
        private Dish startingItem;

        public Main()
        {
            InitializeComponent();

            startingItem = new Dish("", "massa");
            startingItem.AddDishWithoutMainFeature(new Dish("Bolo de chocolate", ""));
            startingItem.AddDishWithMainFeature(new Dish("Lasanha", ""));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            Dish actualItem = startingItem,
                lastItem = null,
                lastDish = null;
            bool correctAnswer = false;
            string lastMove = "";

            do
            {
                if (string.IsNullOrWhiteSpace(actualItem.GetName()))
                {
                    lastItem = actualItem;
                    if (GuessFeature(actualItem))
                    {
                        lastMove = "R";
                        actualItem = actualItem.GetDishWithMainFeature();
                    }
                    else
                    {
                        lastMove = "L";
                        actualItem = actualItem.GetDishWithoutMainFeature();
                    }
                }
                else
                {
                    if (GuessDish(actualItem))
                    {
                        correctAnswer = true;
                    }
                    else
                    {
                        lastDish = actualItem;
                        actualItem = actualItem.GetDishWithoutMainFeature();
                    }
                }
            }
            while (actualItem != null && !correctAnswer);

            if (correctAnswer)
            {
                FinishGame();
            }
            else
            {
                AddNewDish(lastItem, lastDish, lastMove);
            }

        }

        private bool GuessFeature(Dish dish)
        {
            return MessageBox.Show("O Prato que você pensou é " + dish.GetMainFeature() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private bool GuessDish(Dish dish)
        {
            return MessageBox.Show("O Prato que você pensou é " + dish.GetName() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private void FinishGame()
        {
            MessageBox.Show("Acertei de novo!", "Fim de Jogo", MessageBoxButtons.OK);
        }

        private void AddNewDish(Dish lastFeature, Dish lastDish, string lastMove)
        {
            string trueDishName = vbInteraction.InputBox("Qual prato você pensou?", "Desisto", string.Empty, 200, 200);

            string trueDishMainFeature = vbInteraction.InputBox(trueDishName + "é _____ mas " + lastDish.GetName() + " não.", "Complete", string.Empty, 200, 200);

            if (string.IsNullOrWhiteSpace(trueDishMainFeature.Trim()) || string.IsNullOrWhiteSpace(trueDishName.Trim()))
                MessageBox.Show("Não consegui identificar o novo prato, que pena!", "", MessageBoxButtons.OK);
            else
            {
                Dish newFeature = new Dish("", trueDishMainFeature),
                    newDish = new Dish(trueDishName, "");

                newFeature.AddDishWithoutMainFeature(lastDish);
                newFeature.AddDishWithMainFeature(newDish);

                //verifica se a ultima confirmação de característica foi positiva ou negativa
                if(lastMove == "L")
                    lastFeature.AddDishWithoutMainFeature(newFeature);
                else
                    lastFeature.AddDishWithMainFeature(newFeature);
            }
        }
    }
}
