USE NotesDb;
GO

INSERT INTO Notes ("ContactId", "Content", "CreatedAt", "Tags", "Title")
VALUES
    (1, 'Perform code review for team project.', '2024-12-09 08:02:19.970', 'code,review', 'Code Review'),
    (7, 'Present logo redesign concepts.', '2024-12-09 08:02:19.970', 'logo,design', 'Logo Redesign'),
    (1, 'Plan migration to cloud infrastructure.', '2024-12-09 08:02:19.970', 'cloud,migration', 'Cloud Migration'),
    (2, 'Consolidate feedback from client meeting.', '2024-12-09 08:02:19.970', 'feedback,client', 'Client Feedback'),
    (7, 'Prepare materials for React training session.', '2024-12-09 08:02:19.970', 'training,react', 'React Training'),
    (2, 'Compile list of vendors for event.', '2024-12-09 08:02:19.970', 'vendors,event', 'Vendor List'),
    (3, 'Draft DevOps strategy document.', '2024-12-09 08:02:19.970', 'DevOps,strategy', 'DevOps Strategy'),
    (6, 'Visit shortlisted venues for event.', '2024-12-09 08:02:19.970', 'venue,scouting', 'Venue Scouting'),
    (3, 'Update portfolio with recent projects.', '2024-12-09 08:02:19.970', 'portfolio,update', 'Portfolio Update'),
    (7,'Finalize itinerary for corporate retreat.', '2024-12-09 08:02:19.970', 'event,itinerary', 'Event Itinerary'),
    (4, 'Review project budget for Q1.', '2024-12-09 08:02:19.970', 'budget,finance', 'Budget Review'),
    (7, 'Complete SEO audit for blog.', '2024-12-09 08:02:19.970', 'SEO,audit', 'SEO Audit'),
    (5, 'Draft updated brand guidelines.', '2024-12-09 08:02:19.970', 'brand,guidelines', 'Brand Guidelines'),
    (2, 'Conduct UX audit for e-commerce client.', '2024-12-09 08:02:19.970', 'audit,UX', 'UX Audit'),
    (5, 'Write ad copy for campaign.', '2024-12-09 08:02:19.970', 'ad,copywriting', 'Ad Copywriting'),
    (8, 'Prepare documents for kickoff meeting.', '2024-12-09 08:02:19.969', 'meeting,project', 'Project Kickoff'),
    (6, 'Draft content calendar for social media.', '2024-12-09 08:02:19.970', 'content,calendar', 'Content Calendar'),
    (8, 'Document API integration process.', '2024-12-09 08:02:19.970', 'API,documentation', 'API Integration');