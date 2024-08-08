namespace GymProject.Services.Repository
{
    /// <summary>
    /// Strings of the program's menus and prompts
    /// </summary>
    internal class ManagementRepo
    {
        /// <summary>
        /// Options for the client menu
        /// </summary>
        public static string ClientMenuOptions()
        {
            return "Client management menu\n\n" +
                       "Press 1 to add client\n" +
                       "Press 2 to edit client\n" +
                       "Press 3 to delete client\n" +
                       "Press 4 to list all clients\n" +
                       "Press 5 to return to the main menu";
        }

        /// <summary>
        /// Options for the coach menu
        /// </summary>
        public static string CoachMenuOptions()
        {
            return "Coach management menu\n\n" +
                       "Press 1 to add coach\n" +
                       "Press 2 to edit coach\n" +
                       "Press 3 to delete coach\n" +
                       "Press 4 to list all coaches\n" +
                       "Press 5 to return to the main menu";
        }

        /// <summary>
        /// Options for reactivating coach
        /// </summary>
        public static string ReactivateCoachOptions()
        {
            return "This coach is inactive.\n\n" +
                          "Press 1 to reativate coach\n" +
                          "Press 2 to return to the coach menu";
        }

        /// <summary>
        /// Options for editing coach
        /// </summary>
        public static string EditCoachOptions()
        {
            return "Press 1 to finish editing\n" +
                          "Press 2 to edit first name\n" +
                          "Press 3 to edit last name\n" +
                          "Press 4 to edit gender\n" +
                          "Press 5 to edit date of birth\n" +
                          "Press 6 to edit city\n" +
                          "Press 7 to edit address\n" +
                          "Press 8 to edit phone\n" +
                          "Press 9 to edit e-mail\n" +
                          "Press 10 to edit bank account\n" +
                          "Press 11 to edit profession";
        }
        /// <summary>
        /// Options for reactivating client
        /// </summary>
        public static string ReactivateClientOptions()
        {
            return "This client is inactive.\n\n" +
                          "Press 1 to reativate client\n" +
                          "Press 2 to return to the client menu";
        }

        /// <summary>
        /// Options for editing client
        /// </summary>
        public static string EditClientOptions()
        {
            return "Press 1 to finish editing\n" +
                          "Press 2 to edit first name\n" +
                          "Press 3 to edit last name\n" +
                          "Press 4 to edit gender\n" +
                          "Press 5 to edit date of birth\n" +
                          "Press 6 to edit city\n" +
                          "Press 7 to edit address\n" +
                          "Press 8 to edit phone\n" +
                          "Press 9 to edit e-mail\n" +
                          "Press 10 to edit height\n" +
                          "Press 11 to edit weight";
        }

        /// <summary>
        /// Options for editing bank account
        /// </summary>
        public static string EditBankAccountOptions()
        {
            return "Press 1 to finish editing\n" +
                   "Press 2 to edit bank name\n" +
                   "Press 3 to edit bank branch\n" +
                   "Press 4 to edit account number";
        }

        /// <summary>
        /// Options for editing bank account in fancy menu
        /// </summary>
        public static string[] FancyMenuEditBankAccountOptions()
        {
            return new string[4] {"Finish editing" ,
                   "Edit bank name" ,
                   "Edit bank branch" ,
                   "Edit account number" };
        }

        /// <summary>
        /// Options for the welcome screen
        /// </summary>
        public static string StartProgramOptions()
        {
            return "Welcome to the Gym management program!\n\n" +
                              "Press 1 to access the fancy menu\n" +
                              "Press 2 to access the normal menu\n" +
                              "Press 3 to exit the program";
        }

        /// <summary>
        /// Options for the normal main menu
        /// </summary>
        public static string StartNormalMenuOptions()
        {
            return "Welcome to the Gym management program!\n\n" +
                              "Press 1 to access the gym's clients\n" +
                              "Press 2 to access the gym's coaches\n" +
                              "Press 3 to return to the menu selection\n" +
                              "Press 4 to exit the program";
        }

        /// <summary>
        /// Title for the fancy main menu
        /// </summary>
        public static string FancyMainMenuTitle()
        {
            return "Welcome to the Gym management program!\n" +
                     "(Use the up/down arrow keys to navigate options and then enter to select an option.)\n\n";
        }

        /// <summary>
        /// Options for the fancy main menu
        /// </summary>
        public static string[] FancyMainMenuOptions()
        {
            return new string[4]    { "Access the gym's clients",
                                       "Access the gym's coaches",
                                       "Return to menu selection",
                                       "Exit the program" };
        }

        /// <summary>
        /// Options for the fancy client menu
        /// </summary>
        public static string[] FancyClientMenuOptions()
        {
            return new string[5] {  "Add client",
                                        "Edit client",
                                        "Delete client",
                                        "List all clients",
                                        "Return to the main menu" };
        }

        /// <summary>
        /// Title for the fancy client menu
        /// </summary>
        public static string FancyClientMenuTitle()
        {
            return "Client management menu\n" +
                     "(Use the up/down arrow keys to navigate options and then enter to select an option.)\n\n";
        }

        /// <summary>
        /// Options for the fancy client edit menu
        /// </summary>
        public static string[] FancyClientMenuEditOptions()
        {
            return new string[11]{"Finish editing",
                                          "Edit first name",
                                          "Edit last name",
                                          "Edit gender",
                                          "Edit date of birth",
                                          "Edit city",
                                          "Edit address",
                                          "Edit phone",
                                          "Edit e-mail",
                                          "Edit height",
                                          "Edit weight" };
        }

        /// <summary>
        /// Options for the fancy reactivate client menu
        /// </summary>
        public static string[] FancyClientMenuReactivateOptions()
        {
            return new string[2] { "Reativate client",
                                   "Return to the client menu" };
        }

        /// <summary>
        /// Title for the fancy reactivate client menu
        /// </summary>
        public static string FancyClientMenuReactivateTitle()
        {
            return "This client is inactive.\n\n";
        }

        /// <summary>
        /// Options for the fancy coach menu
        /// </summary>
        public static string[] FancyCoachMenuOptions()
        {
            return new string[5] {  "Add coach",
                                        "Edit coach",
                                        "Delete coach",
                                        "List all coaches",
                                        "Return to the main menu" };
        }

        /// <summary>
        /// Title for the fancy coach menu
        /// </summary>
        public static string FancyCoachMenuTitle()
        {
            return "Coach management menu\n" +
                     "(Use the up/down arrow keys to navigate options and then enter to select an option.)\n\n";
        }

        /// <summary>
        /// Options for the fancy coach edit menu
        /// </summary>
        public static string[] FancyCoachMenuEditOptions()
        {
            return new string[11]{"Finish editing",
                                          "Edit first name",
                                          "Edit last name",
                                          "Edit gender",
                                          "Edit date of birth",
                                          "Edit city",
                                          "Edit address",
                                          "Edit phone",
                                          "Edit e-mail",
                                          "Edit bank account",
                                          "Edit profession" };
        }

        /// <summary>
        /// Options for the fancy reactivate coach menu
        /// </summary>
        public static string[] FancyCoachMenuReactivateOptions()
        {
            return new string[2] { "Reativate coach",
                                   "Return to the coach menu" };
        }

        /// <summary>
        /// Title for the fancy reactivate coach menu
        /// </summary>
        public static string FancyCoachMenuReactivateTitle()
        {
            return "This coach is inactive.\n\n";
        }
    }
}
