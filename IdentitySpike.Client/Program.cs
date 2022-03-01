using IdentityModel.Client;

using var client = new HttpClient();

using var cts = new CancellationTokenSource(millisecondsDelay: 30_000);

while (!cts.IsCancellationRequested)
{
	var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

	Console.WriteLine("{0} {1}", DateTime.UtcNow, disco.Error);
	Console.WriteLine("{0} {1}", DateTime.UtcNow, disco.ClaimsSupported);

	await Task.Delay(millisecondsDelay: 1_000);
}

Console.ReadKey();
