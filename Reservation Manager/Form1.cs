using Newtonsoft.Json;

namespace Reservation_Manager
{
    public partial class Form1 : Form
    {
        private Dictionary<string, reservation> toStringToReservation = new Dictionary<string, reservation>();

        // Initialize a list of reservations
        private List<reservation> reservations = new List<reservation>();
        public Form1()
        {
            InitializeComponent();
        }

        public static async Task<HttpResponseMessage> DeleteAsync (string? requestUri)
        {
            using var client = new HttpClient();

            var result = await client.DeleteAsync(requestUri);

            return result;
        }



        private async void Form1_Load(object sender, EventArgs e)
        {


            // Make a get request to api to return all reservations in json format
            dynamic response = await api.makeRequest("https://7157-108-214-189-156.ngrok-free.app/api/v1/reservations");
            
            // Create reservation objects
            foreach (dynamic item in response)
            {
                reservation reservation = new reservation();
                reservation.partyName= item.partyName;
                reservation.email= item.email;
                reservation.phone = item.phone;
                reservation.size= item.size;
                reservation.time= item.time;
                reservation.date = item.date;
                reservation.requests = item.requests;

                // Add reservation to list
                reservations.Add(reservation);
            }

            // Write each reservation object into the list box
            foreach (reservation reservation in reservations)
            {
                toStringToReservation.Add(reservation.toString(), reservation);
                reservationBox.Items.Add(reservation.toString());
            }
        }


     
        private void reservationBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            // base url for deleting reservations
            string baseUrl = "https://7157-108-214-189-156.ngrok-free.app/api/v1/reservations/";

            
            if (reservationBox.SelectedItem != null)
            {
                //Get the current selected reservation from the list box
                reservation currentSelected = toStringToReservation[reservationBox.SelectedItem.ToString()];

                //Create the full url for http delete
                string fullUrl = baseUrl + currentSelected.partyName;

               
                // Delete the reservation
                await DeleteAsync(fullUrl);

                //Remove from Dictionary and List
                toStringToReservation.Remove(currentSelected.toString());
                reservations.Remove(currentSelected);

                label1.Text = "Reservation Removed";

            }
            else
            {
                //Throw an error if nothing is selected
                label1.Text = "Error: Please Select a Value";
            }

        }
    }
}