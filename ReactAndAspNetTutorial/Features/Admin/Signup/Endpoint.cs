namespace Admin.Signup
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Verbs(Http.POST); 
            Post("/admin/signup/");
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            await SendAsync(new Response()
            {
                Message = $"hello {r.FirstName} {r.LastName}! Your request has been received"
            });
        }
    }
}