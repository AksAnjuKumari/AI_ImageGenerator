using Azure;
using Azure.AI.OpenAI;
using OpenAI.Images;
using System;
using System.Threading.Tasks;
namespace AI_ImageGenerator.Models
{
    
        public class ImageGenerator
        {
            private readonly AzureOpenAIClient _azureClient;

            public ImageGenerator()
            {
                string key = "YOUR KEY HERE";
                Uri aiEndpoint = new Uri("YOUR ENDPOINT HERE");
                AzureKeyCredential credential = new AzureKeyCredential(key);
                _azureClient = new AzureOpenAIClient(aiEndpoint, credential);
            }

            public async Task<string> GenerateImageAsync(string userPrompt)
            {
                try
                {
                    var imageClient = _azureClient.GetImageClient("dall-e-3");
                    System.ClientModel.ClientResult<GeneratedImage> imageResult = await imageClient.GenerateImageAsync(userPrompt, new ImageGenerationOptions()
                    {
                        Quality = GeneratedImageQuality.Standard,
                        Size = GeneratedImageSize.W1024xH1024,
                       // Size = GeneratedImageSize.W512xH512,
                        ResponseFormat = GeneratedImageFormat.Uri
                    });

                    GeneratedImage image = imageResult.Value;
                    return image.ImageUri.ToString();
                }
                catch (Exception ex)
                {
                    return $"An error occurred: {ex.Message}";
                }
            }
        }    

}
