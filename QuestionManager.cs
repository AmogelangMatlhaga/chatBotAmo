using System;

namespace chatBotAmo
{
    public class QuestionManager
    {
        public string GetResponses(string input)
        {
            string[] words = input.ToLower().Split(new char[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);

            //keywords for the arrays
            string[] purposeKeywords = { "purpose" };
            string[] cybersecurityKeywords = { "cybersecurity", "cyber", "security" };
            string[] examplesKeywords = { "examples" };
            string[] virusKeywords = { "virus", "harmful program" };
            string[] ransomwareKeywords = { "ransomware", "harmful software" };
            string[] spywareKeywords = { "spyware", "typr of software" };
            string[] databreachKeywords = { "data breach", "stolen" };
            string[] phishingKeywords = { "phishing", "phish", "fake email", "scam" };
            string[] passwordSafetyKeywords = { "password", "safe password", "password safety", "password manager" };
            string[] safeBrowsingKeywords = { "safe browsing", "browsing", "safe" };
            string[] browsingKeywords = { "browsing", "safe browsing", "safe" };
            string[] denialofservicesKeywords = { "overload", "hackers" };
            string[] malwareKeywords = { "malware" };
            string[] waystopreventcyberattcksKeywords = { "prevent", "ways" };

            //responses for the arrays
            string[] responses = new string[14];

            foreach (string word in words)
            {
                //responses for purpose
                if (Array.Exists(purposeKeywords, element => element == word))
                    responses[0] = "My purpose is to educate you about online safety and cybersecurity.";
                //responses for cybersecurity
                if (Array.Exists(cybersecurityKeywords, element => element == word))
                    responses[1] = " Cybersecurity is the practice of protecting systems, networks, and data from cyber threats, unauthorized access, and digital attacks." +
                        $"you can ask me for examples of cyber attacks";
                //responses for examples of cybersecurity attacks
                if (Array.Exists(examplesKeywords, element => element == word))
                    responses[2] = "Examples of cyber threats include viruses, phishing, ransomware, spyware, data breaches, denial-of-service attacks, and malware.";
                //responses for viruses
                if (Array.Exists(virusKeywords, element => element == word))
                    responses[3] = " A computer virus is a harmful program that spreads between computers and can damage files or steal information.";
                //responses for ransomware
                if (Array.Exists(ransomwareKeywords, element => element == word))
                    responses[4] = "Ransomware is a type of harmful software that locks or blocks access to files or systems until a ransom is paid.";
                //responses for spyware
                if (Array.Exists(spywareKeywords, element => element == word))
                    responses[5] = "Spyware is a type of software that secretly collects information from a computer or phone without the user knowing.";
                //responses for databreaches
                if (Array.Exists(databreachKeywords, element => element == word))
                    responses[6] = "Data breaches happen when private or secret information is stolen or shared without permission.";
                //responses for phishing
                if (Array.Exists(phishingKeywords, element => element == word))
                    responses[7] = "Phishing is a type of cyber attack where attackers trick users into giving out their personal information. This is usually done through email or text messages.";
                //resnponse for password safety
                if (Array.Exists(passwordSafetyKeywords, element => element == word))
                    responses[8] = "Password safety is important because it helps protect your personal information from being stolen. You should always use strong, unique passwords for each of your accounts.";
                //response for safe browsing
                if (Array.Exists(safeBrowsingKeywords, element => element == word))
                    responses[9] = "Safe browsing is important because it helps protect your computer from malware and other online threats. You should always use a secure browser and keep your software up to date.";
                //responses for denial of services
                if (Array.Exists(denialofservicesKeywords, element => element == word))
                    responses[10] = "A denial-of-service (DoS) attack is when hackers overload a website or network with too much traffic, making it slow or unavailable for real users.";
                //responses for malware
                if (Array.Exists(malwareKeywords, element => element == word))
                    responses[11] = "Malware is harmful software that can damage or steal information from a computer or device.";
                //responses for ways to prevent cyber attacks
                if (Array.Exists(waystopreventcyberattcksKeywords, element => element == word))
                    responses[12] = " Use Strong Passwords and Multi-Factor Authentication (MFA): Ensure all accounts have complex, unique passwords, and enable MFA to add an extra layer of security.\r\n\r\nKeep Software and Systems Updated: Regularly update operating systems, software, and applications to patch known vulnerabilities that could be exploited by attackers.\r\n\r\nEducate Employees or Users About Phishing and Social Engineering: Train individuals to recognize phishing attempts and malicious links to prevent attackers from gaining unauthorized access.\r\n\r\nInstall and Maintain Reliable Security Software: Use firewalls, antivirus software, and intrusion detection systems to detect and block malicious activity on your network.";
            }
            //responses that are not null
            string finalResponse = string.Join(" ", Array.FindAll(responses, element => element != null));
            return !string.IsNullOrEmpty(finalResponse) ? finalResponse : "I'm sorry, I don't understand. Please ask me a question about phishing, password safety, or safe browsing.";


        }
    }
}