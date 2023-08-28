# MailLobbyer-Demo
This is a demonstration version of my CSV group-based emailing tool built using WASM Blazor. While this demo version doesn't have full SMTP integration functionality due to sandboxing and security measures built into WebAssembly, it serves as an excellent showcase of how the MailLobbyer tool operates.

# Features:
- CSV Upload: Upload a CSV file containing contact information and email addresses.
- Attachments: Easily upload attachments to be sent included with each email.
- Exclusion Selection: Select specific contacts from the uploaded CSV to exclude.
- Email Personalization: Customize email content for each contact with built in syntax.
- User-friendly Interface: Intuitive user interface for a seamless experience.

# Features found in the closed source tool:
While MailLobbyer-demo provides a demonstration into the capabilities of the CSV group-based emailing tool, the actual version built using Blazor Server offers a range of advanced features that enhance its functionality, usability, and practicality. Here are some key differences:

- Users can select from multiple stored CSV files, making it easier to manage and switch between different contact lists.
- A search feature is available, allowing users to quickly find specific contacts to exclude from batch emails.
- Email sending is optimized through multithreaded asynchronous threads, preventing the UI freezing up as it is no longer client sided and allows batches of emails to be sent at a faster rate.
- Rate limiting to prevent triggering anti-spam measures enforced by SMTP servers (e.g., Gmail, Outlook).
- Users have the ability to schedule emails to be sent ahead of time.
- MailLobbyer is built using Blazor Server, which offers real-time interactions and updates without the restrictions imposed by WebAssembly's sandboxing, client side execution and security measures.