using System;

namespace chatBotAmo
{
    public class QuestionManager
    {
        // Create a Random object for selecting random responses
        private Random random = new Random();

        // Main method to process user input and return chatbot response
        public string GetResponses(string input)
        {
            // If input is null, empty, or whitespace, return a default message
            if (string.IsNullOrWhiteSpace(input))
                return "I didn't quite understand that. Could you rephrase?";

            // Normalize input by converting to lowercase and trimming spaces
            input = input.ToLower().Trim();

            // Handle specific hard-coded phrases
            if (input == "how are you")
                return "I'm just a bot, but I'm functioning properly! How can I help you with cybersecurity?";

            if (input.Contains("what can i ask"))
                return "You can ask me about cybersecurity topics like phishing, password safety, safe browsing, malware, ransomware, and more!";

            // Split input into words for keyword matching
            string[] words = input.Split(new char[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);

            // Define keyword arrays for various cybersecurity topics
            string[] phishingKeywords = { "phishing", "phish", "fake email", "scam" };
            string[] passwordKeywords = { "password", "passwords", "password safety", "safe password", "password manager" };
            string[] browsingKeywords = { "safe browsing", "browsing", "browser", "safe" };
            string[] virusKeywords = { "virus", "viruses", "harmful program" };
            string[] ransomwareKeywords = { "ransomware", "harmful software" };
            string[] spywareKeywords = { "spyware", "type of software" };
            string[] dataBreachKeywords = { "data breach", "breach", "stolen" };
            string[] malwareKeywords = { "malware" };
            string[] dosKeywords = { "denial", "overload", "hackers", "dos" };
            string[] purposeKeywords = { "purpose" };
            string[] exampleKeywords = { "examples" };

            // Define keywords for detecting sentiment
            string[] worriedKeywords = { "worried", "concerned" };
            string[] curiousKeywords = { "curious", "interested" };
            string[] frustratedKeywords = { "frustrated", "angry" };
            string[] confusedKeywords = { "confused", "unclear" };

            // Arrays of potential responses for each topic
            string[] phishingResponses = {
                "You must always be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
                "Phishing is a cyberattack where attackers trick individuals into revealing sensitive information by posing as a trustworthy entity. Always check email addresses carefully, phishing emails often come from addresses that look suspicious or fake.",
                "Avoid clicking on links in unsolicited emails. Instead, visit the official website directly.",
                "Phishing scams often create a sense of urgency—don’t fall for the pressure."
            };

            string[] passwordResponses = {
                "Password safety refers to the practice of creating, using, and managing strong, unique passwords to protect accounts and personal information from unauthorized access. Use a mix of uppercase, lowercase, numbers, and special characters for strong passwords.",
                "Try to avoid using the same password across multiple sites to ensure password safety.",
                "Consider using a password manager to generate and store your passwords securely.",
                "Never share your password with anyone, even someone claiming to be tech support."
            };

            string[] browsingResponses = {
                "Safe browsing refers to practices that protect users from online threats, such as malware, phishing scams, and infected websites, to ensure a secure online experience. Keep your browser up to date to stay protected from known vulnerabilities.",
                "Safe browsing is when you avoid clicking pop-ups or downloading files from unknown websites.",
                "Use a browser that offers privacy features and ad-blocking.",
                "Always look for HTTPS in the URL when entering sensitive information."
            };

            string[] virusResponses = {
                "A computer virus is a harmful program designed to spread from one device to another.",
                "Viruses can delete files, slow down systems, or steal personal data.",
                "Most viruses spread via infected email attachments or downloads.",
                "Using reliable antivirus software helps detect and remove viruses."
            };

            string[] ransomwareResponses = {
                "Ransomware is a type of malware that encrypts a victim's files and demands payment in exchange for the decryption key. Ransomware locks your data until you pay a ransom to the attacker.",
                "It's often spread through malicious email attachments or software downloads.",
                "Regularly back up your files to protect against ransomware.",
                "Avoid clicking unknown links to prevent ransomware infections."
            };

            string[] spywareResponses = {
                "Spyware is malicious software that secretly monitors and collects sensitive information, such as browsing habits, personal data, or login credentials, without the user's consent. Spyware secretly monitors your activity and sends the data to attackers.",
                "It can be installed without your knowledge through bundled software.",
                "Using antispyware tools and being cautious online can help prevent it.",
                "Spyware often slows down your system and compromises your privacy."
            };

            string[] breachResponses = {
                "A data breach happens when unauthorized people access private data.",
                "Breach victims can face identity theft or fraud.",
                "Use strong passwords and enable 2FA to reduce the risk.",
                "Organizations should encrypt data to prevent breaches."
            };

            string[] malwareResponses = {
                "Malware is malicious software designed to harm, exploit, or compromise a computer system, steal sensitive information, or disrupt digital operations. Malware includes viruses, spyware, ransomware, and more.",
                "It can damage or steal data from your devices.",
                "Installing antivirus and updating software reduces malware risk.",
                "Avoid shady websites and unverified downloads to stay safe."
            };

            string[] dosResponses = {
                "A Denial of Service (DoS) attack is a type of cyber attack that overwhelms a system or network with traffic, rendering it unavailable to users. A Denial-of-Service (DoS) attack floods a system with traffic, making it unusable.",
                "These attacks aim to shut down websites or services.",
                "Using firewalls and load balancers can help prevent DoS attacks.",
                "Distributed DoS (DDoS) attacks use many devices to overwhelm systems."
            };

            string[] exampleResponses = {
                "Examples of cyber threats include viruses, phishing, ransomware, spyware, data breaches, denial-of-service attacks, and malware.",
                "Common cyber attacks include phishing scams, malware infections, and unauthorized access to systems.",
                "Hackers use ransomware, spyware, and social engineering to carry out attacks.",
                "Cyber threats evolve constantly—always stay alert and informed."
            };

            string[] purposeResponses = {
                "My purpose is to educate you about online safety and cybersecurity.",
                "I'm here to help you understand and defend against cyber threats.",
                "My goal is to make cybersecurity simple and accessible.",
                "Ask me anything about staying safe online!"
            };

            // This will hold the final response selected
            string finalResponse = null;

            // Loop through each word in the input and check against keyword arrays
            foreach (string word in words)
            {
                if (Array.Exists(phishingKeywords, w => w == word))
                    finalResponse = phishingResponses[random.Next(phishingResponses.Length)];
                else if (Array.Exists(passwordKeywords, w => w == word))
                    finalResponse = passwordResponses[random.Next(passwordResponses.Length)];
                else if (Array.Exists(browsingKeywords, w => w == word))
                    finalResponse = browsingResponses[random.Next(browsingResponses.Length)];
                else if (Array.Exists(virusKeywords, w => w == word))
                    finalResponse = virusResponses[random.Next(virusResponses.Length)];
                else if (Array.Exists(ransomwareKeywords, w => w == word))
                    finalResponse = ransomwareResponses[random.Next(ransomwareResponses.Length)];
                else if (Array.Exists(spywareKeywords, w => w == word))
                    finalResponse = spywareResponses[random.Next(spywareResponses.Length)];
                else if (Array.Exists(dataBreachKeywords, w => w == word))
                    finalResponse = breachResponses[random.Next(breachResponses.Length)];
                else if (Array.Exists(malwareKeywords, w => w == word))
                    finalResponse = malwareResponses[random.Next(malwareResponses.Length)];
                else if (Array.Exists(dosKeywords, w => w == word))
                    finalResponse = dosResponses[random.Next(dosResponses.Length)];
                else if (Array.Exists(exampleKeywords, w => w == word))
                    finalResponse = exampleResponses[random.Next(exampleResponses.Length)];
                else if (Array.Exists(purposeKeywords, w => w == word))
                    finalResponse = purposeResponses[random.Next(purposeResponses.Length)];
                else if (Array.Exists(worriedKeywords, w => w == word))
                    finalResponse = "I understand your concerns. Cybersecurity is important, and I'm here to help you.";
                else if (Array.Exists(curiousKeywords, w => w == word))
                    finalResponse = "That's great! I'm glad you're interested in learning more about cybersecurity.";
                else if (Array.Exists(frustratedKeywords, w => w == word))
                    finalResponse = "I understand that this can be frustrating. Let's work together to find the information you need.";
                else if (Array.Exists(confusedKeywords, w => w == word))
                    finalResponse = "I understand that this can be confusing. Let's clarify any questions you have.";
            }

            // Return selected response or fallback message
            return finalResponse ?? "I didn't quite understand that. Could you rephrase or ask me about topics like phishing, password safety, or safe browsing?";
        }
    }
}




