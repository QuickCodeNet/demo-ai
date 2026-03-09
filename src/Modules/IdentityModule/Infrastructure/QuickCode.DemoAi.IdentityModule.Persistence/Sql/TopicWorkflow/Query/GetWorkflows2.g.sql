SELECT [Id], [KafkaEventsTopicName], [WorkflowContent] 
FROM [TopicWorkflows] 
WHERE [IsDeleted] = 0 
	AND [KafkaEventsTopicName] = @PRM_TopicWorkflow_KafkaEventsTopicName 
ORDER BY [Id] 