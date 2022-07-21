import React, { useCallback } from 'react';
import { Button, Label, Link, Text } from '@fluentui/react-components';
import { Card, CardFooter, CardHeader, CardPreview } from '@fluentui/react-components/unstable';
import { CodeRegular, DatabaseRegular, BookOpenRegular } from '@fluentui/react-icons';
import { useStyles } from '../styles/styles';
import { Calculate } from './Calculate';

const gitHubUrl = "https://github.com/achappey/Simplicator";
const simplicateUrl = "https://www.simplicate.com";
const customConnectorUrl = "https://docs.microsoft.com/en-us/connectors/custom-connectors/define-openapi-definition";

export const Home: React.FunctionComponent = () => {
  const classes = useStyles();

  const openGitHub = useCallback(() => {
    window.open(gitHubUrl, "_blank")
  }, [])

  const openSwagger = useCallback(() => {
    window.open("/swagger", "_blank")
  }, [])

  const openMetadata = useCallback(() => {
    window.open("/odata/$metadata", "_blank")
  }, [])

  const simplicatorHeader = <Label size='large'>Simplicator</Label>
  const powerPlatformHeader = <Label size='large'>Power Platform</Label>
  const authenticationHeader = <Label size='large'>Authentication</Label>

  const swaggerIcon = <BookOpenRegular fontSize={16} />
  const oDataIcon = <DatabaseRegular fontSize={16} />
  const sourceIcon = <CodeRegular fontSize={16} />

  return <>
    <h2>Unofficial Power Platform connector for <Link href={simplicateUrl} target={"_blank"}>Simplicate</Link></h2>

    <Card className={classes.card}>
      <CardHeader header={simplicatorHeader} />
      <CardPreview className={classes.cardDescripton}>
        <Text>Simplicator is an application proxy between the Power Platform and Simplicate.</Text>
        <Text>Requests and responses are forwarded and sent back only, data is not stored anywhere.</Text>
      </CardPreview>
      <CardFooter>
        <Button onClick={openSwagger} icon={swaggerIcon}> Swagger</Button>
        <Button onClick={openMetadata} icon={oDataIcon}> OData</Button>
        <Button onClick={openGitHub} icon={sourceIcon}> Source</Button>
      </CardFooter>
    </Card>

    <Card className={classes.card}>
      <CardHeader header={powerPlatformHeader} />
      <CardPreview className={classes.cardDescripton}>
        <Text>For example, retrieve all your Simplicate projects in Power BI:</Text>

        <pre className={classes.wrap}>
          OData.Feed("https://simplicator.net/odata/projects", null, [ApiKeyName="x-api-key", Implementation = "2.0"])
        </pre>

        <Text>Or <Link href={customConnectorUrl} target={"_blank"}>create</Link> a custom connector from <Link href={"/swagger/v2/swagger.json"} target={"_blank"}>this</Link> file to use Power Automate actions.</Text>
      </CardPreview>
    </Card>

    <Card className={classes.card}>
      <CardHeader header={authenticationHeader} />
      <CardPreview className={classes.cardDescripton}>
        <Text>Add as query string or in the request header.</Text>

        <pre className={classes.wrap}>x-api-key: base64Encode([ApiKey]:[ApiSecret]@[Environment])</pre>

      </CardPreview>
    </Card>

    <Calculate />
  </>
}
