using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;


Console.WriteLine("Starting Blob Upload");

ProcessAsync().GetAwaiter().GetResult();

Console.WriteLine("End Blob Upload");
Console.ReadKey();



static async Task ProcessAsync(){

    string storage_connectionstring = "DefaultEndpointsProtocol=https;AccountName=mstestblob;AccountKey=yTjGahNfaLCPr5wlllwgKXYk/oN0l5Hi265DYOZpljVzaqpeb79wHlrzTiiCrpmDatQZXk4sOazI+AStua1/yw==;EndpointSuffix=core.windows.net";

    BlobServiceClient client = new BlobServiceClient(storage_connectionstring);

    string fileName = "applog.txt";
    // string filepath = Path.Combine("./data/", fileName);

    // FileStream fs = File.OpenRead(filepath);

    var containers = client.GetBlobContainersAsync(BlobContainerTraits.Metadata, "", default).AsPages(default, 100);

    await foreach (Azure.Page<BlobContainerItem> item in containers)
    {
        foreach(var container in item.Values){
            Console.WriteLine($"{container.Name} {container.VersionId}");
        }
    }

    // BlobContainerClient containerClient = await client.();
    // BlobClient blobClient = containerClient.GetBlobClient(fileName);
    // //await blobClient.UploadAsync(fs, true);

    // await blobClient.DeleteAsync();


}
