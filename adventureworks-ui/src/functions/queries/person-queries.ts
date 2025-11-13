import { gql } from '@apollo/client';

export const GET_PERSONS = gql`
  query GetPersons($first: Int, $after: String) {
    personsEndpoint(first: $first, after: $after) {
      nodes {
        businessEntityId
        title
        firstName
        middleName
        lastName
        personType
        suffix
        isActive
        emailPromotion
      }
      pageInfo {
        hasNextPage
        endCursor
      }
    }
  }
`;

export const GET_PERSONS_LIST = gql`
query($amount: Int!) {
    personsList(amount: $amount) {
        edges {
            node {
                businessEntityId
                firstName
                personType
                title
            }
        }
    }
} 
`;
