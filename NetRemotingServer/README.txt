Be sure to add this snippet to your newrelic.config file to enable instrumentation of this process

	<instrumentation>
		<applications>
		  <application name="NetRemotingServer.exe" />
		  <application name="NETREMOTINGSERVER.EXE" />
		</applications>
	</instrumentation>