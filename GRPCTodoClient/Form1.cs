
namespace GRPCTodoClient
{
    public partial class Form1 : Form
    {
        private GrpcClient _grpcClient;
        public Form1()
        {
            InitializeComponent();

            _grpcClient = new GrpcClient();
        }

        private async void btnAddTodo_ClickAsync(object sender, EventArgs e)
        {
            await _grpcClient.AddTodoAsync(txtTodoTitle.Text);
        }

        private async void btnStartStreaming_Click(object sender, EventArgs e)
        {
            await _grpcClient.StreamTodoUpdatesAsync();
        }
    }
}
