'use client';
import { ApolloClient, InMemoryCache, gql, ApolloProvider, useQuery } from '@apollo/client';
export { ApolloClient, InMemoryCache, gql, ApolloProvider, useQuery };
import { GET_PERSONS_LIST_NO_PARAMETER } from './functions/queries/personQueries';
import { Person } from '@/app/models/personModel';

// Define the shape of the GraphQL response
interface PersonNode {
  node: Person;
}

interface PersonsListResponse {
  personsList: {
    edges: PersonNode[];
  };
}

export default function PersonsPage() {
  // Type the useQuery hook with the response shape
  const { data, loading, error } = useQuery<PersonsListResponse>(
    GET_PERSONS_LIST_NO_PARAMETER,
    { variables: { amount: 5 } } // after removed since your query doesn't have it
  );

  if (loading) return <html><body><p>Loading...</p></body></html>;
  if (error) return <html><body><p>Error: {error.message}</p></body></html>;

  // Map edges to nodes
  const nodes = data?.personsList.edges.map(edge => edge.node) ?? [];

  return (
    <html>
      <body>
        <ul>
          {nodes.map(person => (
            <li key={person.businessEntityId}>
              {person.title} {person.firstName} {person.personType}
            </li>
          ))}
        </ul>
      </body>
    </html>
  );
}
